import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray, Form } from '@angular/forms';
import { RecipesService } from 'src/app/services/recipesService/recipes.service';
import { RegisterService } from 'src/app/services/register.service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

interface ComplexityLevel {
  value: number;
  viewValue: string;
}

interface Ingredient {
  name: string;
  unit: string;
  quantity: number;
}

interface Step {
  instruction: string;
}

@Component({
  selector: 'app-recipe-add',
  templateUrl: './recipe-add.component.html',
  styleUrls: ['./recipe-add.component.scss']
})
export class RecipeAddComponent implements OnInit {
  // Complexity levels
  complexityLevels: ComplexityLevel[] = [{
      value: 1,
      viewValue: 'Easy'
    },
    {
      value: 2,
      viewValue: 'Intermediate'
    },
    {
      value: 3,
      viewValue: 'Advanced'
    }
  ]

  // Form variables
  ingredients: FormArray;
  steps: FormArray;
  form: FormGroup;
  helper = new JwtHelperService();


  constructor(private fb: FormBuilder, private recipeService: RecipesService, private userService: RegisterService, private router: Router, private snack: MatSnackBar) {
    this.form = this.fb.group({
      name: [''],
      cuisine: [''],
      category: [''],
      complexityLevel: [''],
      estimatedTime: [''],
      ingredients: this.fb.array([this.createIngredient()]),
      steps: this.fb.array([this.createStep()]),
    });
  }

  ngOnInit() {}

  // Image manegement
  url: string;
  file = undefined;
  onSelectFile(event) {
    const self = this;
    if (event.target.files && event.target.files[0]) {
      var reader = new FileReader();
      this.file = event.target.files[0];
      if(this.checkFileType(this.file.type)){
        reader.readAsDataURL(event.target.files[0]); // read file as data url

        reader.onload = (event) => { // called once readAsDataURL is completed
          self.url = event.target.result.toString();
        }
      }else{
        this.snack.open("File extension is wrong. Only .png or .jpg images.", '',{
          duration: 4000,
          panelClass: ['snackbar-wrong'],
          verticalPosition: 'top'
        });
      }
    }
  }

  private checkFileType(fileType:string) : boolean{
    const fileTypeCutted = fileType.split('/');
    if(fileTypeCutted[1] === ('png') || fileTypeCutted[1] === ('jpeg')){
      return true;
    }
    return false;
  }

  // Ingredients
  createIngredient(): FormGroup {
    let ingredient: Ingredient = {
      name: '',
      quantity: 0,
      unit: ''
    }
    
    return this.fb.group(ingredient);
  }

  onIngredientAdd() {
    this.ingredients = this.form.get('ingredients') as FormArray;
    this.ingredients.push(this.createIngredient());
  }

  onIngredientRemove(i) {
    var allIngredients = this.form.get('ingredients') as FormArray;
    allIngredients.removeAt(i);
  }

  get allIngredients() {
    return this.form.get('ingredients') as FormArray;
  }

  // Steps
  createStep(): FormGroup {
    let step: Step = {
      instruction: ''
    }

    return this.fb.group(step);
  }

  onStepAdd() {
    this.steps = this.form.get('steps') as FormArray;
    this.steps.push(this.createStep());
  }

  onStepRemove(i) {
    var allSteps = this.form.get('steps') as FormArray;
    allSteps.removeAt(i);
  }

  get allSteps() {
    return this.form.get('steps') as FormArray;
  }

  // Form submit
  onSubmit() {
    const formValues = this.form.value;

    if(this.form.valid) {
      if(formValues.ingredients.length < 3) {
        this.snack.open("You need to add at least three ingredients!", '',{
          duration: 4000,
          panelClass: ['snackbar-wrong'],
          verticalPosition: 'top'
        });
      } else {
        if(formValues.steps.length < 1) {
          this.snack.open("You need to add at least one step!", '',{
            duration: 4000,
            panelClass: ['snackbar-wrong'],
            verticalPosition: 'top'
          });
        } else {
          const userId = localStorage.getItem('user_id');

          const formData = new FormData();

          let recipeDataForm = {
            creatorId: userId,
            name: formValues.name,
            category: formValues.category,
            cuisine: formValues.cuisine,
            complexityLevel: formValues.complexityLevel,
            estimatedTime: formValues.estimatedTime,
            ingredients: formValues.ingredients,
            steps: formValues.steps
          }

          formData.append('recipe', JSON.stringify(recipeDataForm));
          formData.append('file', this.file);

          this.recipeService.addRecipe(formData).subscribe((response: any) => {
            this.router.navigateByUrl('recipes');
          });
        }
      }
    }
  }
}