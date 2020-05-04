export interface Recipie {
  Category: string;
  CreatorId: string;
  Cuisine: string;
  DateCreated: Date;
  ComplexityLevel: number;
  EstimatedTime: number;
  Id: string;
  Ingredients: Array<Ingredient>;
  Name: string;
  Steps: Array<Step>;
}
export interface Step {
  Id: string;
  instruction: string;
  recipeId: string;
}
export interface Ingredient {
  Id: string;
  Name: string;
  unit: string;
  quantity: number;
  recipeId: string;
}
export class Meal {
  Id: string;
  RecipeId: string;
  Type: string;

  constructor(Id: string, RecipeId: string, Type: string) {
    this.Id = Id;
    this.RecipeId = RecipeId;
    this.Type = Type;
  }
}
