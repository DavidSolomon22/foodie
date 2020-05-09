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
export interface Rate {
  RecipeId: string;
  AuthorId: string;
  Value: number;
  Comment?: string;
}
