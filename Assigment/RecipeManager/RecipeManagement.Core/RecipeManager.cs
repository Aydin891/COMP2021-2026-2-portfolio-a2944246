using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Linq;

namespace RecipeManagement.Core;

/// <summary>
/// Implement this class using the five Part A collections as private fields:
/// Dictionary&lt;int, Recipe&gt;, List&lt;string&gt;, LinkedList&lt;int&gt;,
/// Stack&lt;int&gt; and Queue&lt;string&gt;.
/// </summary>
public sealed class RecipeManager : IRecipeManager
{
    // TODO Part A: add your private collection fields here.
    private Dictionary<int, Recipe> recipes = new();
    private List<String> shoppingList = new();
    private LinkedList<int> cookingPlan = new();
    private Stack<int> removeRecipes = new();
    private Queue<string> instructionQueue = new();
    private List<int> savedReciepes = new();
        

    public RecipeManager(IEnumerable<Recipe> recipes)
    {
        // TODO Part A: validate recipes and build Dictionary<int, Recipe>.

        if (recipes == null)
        {
            throw new ArgumentNullException("recipes");
        }

        foreach (Recipe recipe in recipes)
        {
            if (recipe.Id <= 0)
            {
                throw new ArgumentException("ID of the recipe must be positive.");
            }
            
            if (string.IsNullOrWhiteSpace(recipe.Title))
            {
                throw new ArgumentException("Title of the recipe cant be blank.");
            }

            if (this.recipes.ContainsKey(recipe.Id))
            {
                throw new ArgumentException("Duplicate recipe ID.");
            }

            this.recipes.Add(recipe.Id, recipe);
        }

    }

    public int RecipeCount => recipes.Count;
    public int ShoppingItemCount => shoppingList.Count;
    public int CookingPlanCount => cookingPlan.Count;
    public int PendingInstructionCount => instructionQueue.Count;
    public int RemovedRecipeCount => removeRecipes.Count;

    public bool AddRecipe(Recipe recipe)
    
        {
            if (recipe ==null)
            {
                throw new ArgumentNullException(nameof(recipe));
            }

            if (recipe.Id <=0)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(recipe.Title))
            {
                return false;
            }


            if(recipes.ContainsKey(recipe.Id))
            {
                return false;
            }

            recipes.Add(recipe.Id, recipe);
            return true;

        }

    public Recipe? FindRecipe(int recipeId)
    {
        if (recipes.ContainsKey(recipeId))
        {
            return recipes[recipeId];
        }

        return null;

    }


    public bool RemoveRecipe(int recipeId)
    {
        if (recipes.ContainsKey(recipeId))
        {
            if (cookingPlan.Contains(recipeId))
            {
                return false;
            }

            recipes.Remove(recipeId);
            return true;
        }

        return false;


    }
        

    public int AddIngredientsToShoppingList(int recipeId)
    {
        Recipe? recipe = FindRecipe(recipeId);

        if (recipe == null)
        {
            return 0;
        }

        foreach (string ingredient in recipe.Ingredients)
        {
            shoppingList.Add(ingredient);
        }

        return recipe.Ingredients.Count;
    }

    public IReadOnlyList<string> GetShoppingList()
    {
        return new List<string>(shoppingList);
    }

    public void ClearShoppingList()
    {
        shoppingList.Clear();
    }

    public bool AddRecipeToCookingPlan(int recipeId)
    {
        if(recipes.ContainsKey (recipeId))
        {
            if (cookingPlan.Contains(recipeId))
            {
                return false;
            }
            else
            {
                cookingPlan.AddLast(recipeId);
                return true;
            }

        }
        else
        {
            return false;
        }
    }


    public bool RemoveRecipeFromCookingPlan(int recipeId)
    {

        if (cookingPlan.Contains(recipeId))
        {
            cookingPlan.Remove(recipeId);
            removeRecipes.Push(recipeId);
            return true;
        }
        else
        {
            return false;
        }

    }

    public bool RestoreLastRemovedRecipe()
    {
        if (removeRecipes.Count == 0)
        {
            return false;
        }

        int recipeId = removeRecipes.Pop();

        if (recipes.ContainsKey(recipeId) == false)
        {
            return false;
        }

        if (cookingPlan.Contains(recipeId))
        {
            return false;
        }

        cookingPlan.AddLast(recipeId);
        return true;
    }

    public int? PeekLastRemovedRecipe()
    {
        if (removeRecipes.Count == 0)
        {
            return null;
        }

        return removeRecipes.Peek();
    }

    public IReadOnlyList<int> GetCookingPlan()
    {
        return new List<int>(cookingPlan);
    }

    public bool StartCooking(int recipeId)
    {
        Recipe? recipe = FindRecipe(recipeId);

        if (recipe == null)
        {
            return false;
        }
        
        if (recipe.Instructions.Count == 0)
        {
            return false;
        }

        instructionQueue.Clear();

        foreach (string instruction in recipe.Instructions)
        {
            instructionQueue.Enqueue(instruction);

        }

        return true;
    }

    public string? PeekNextInstruction()
    {
        if (instructionQueue.Count == 0)
        {
            return null;
        }

        return instructionQueue.Peek();
    }
    public string? CompleteNextInstruction()
    {
        if (instructionQueue.Count == 0)
        {
            return null;
        }

        return instructionQueue.Dequeue();
        
    }

    

    public IReadOnlyList<Recipe> SearchByTitle(string searchText)
    {
        if (searchText == "")
        {
            return recipes.Values.ToList();
        }

        string search = searchText.ToLower();

        var result = from recipe in recipes.Values where recipe.Title.ToLower().Contains(search) select recipe;

        if (result.Count() == 0)
        {
            Console.WriteLine("No recipes ha been found");
        }

        return result.ToList();

    }


    public IReadOnlyList<Recipe> SearchByIngredient(string searchText)
    {
        if (searchText == "")
        {
            return recipes.Values.ToList();
        }

        string search = searchText.ToLower();

        var result = from recipe in recipes.Values where recipe.Ingredients.Any(ingredient => ingredient.ToLower().Contains(search)) select recipe;

        if (result.Count() == 0)
        {
            Console.WriteLine("No recipes ha been found");
        }

        return result.ToList();
    }

    public IReadOnlyList<Recipe> GetHighestProteinRecipes(int count)
    {
        if (count <= 0)
        {
            return new List<Recipe>();
        }

        var result = from recipe in recipes.Values 
                    where recipe.Nutrition != null && recipe.Nutrition.ProteinG != null
                    orderby recipe.Nutrition.ProteinG descending
                    select recipe;
        
        return result.Take(count).ToList();
    }
    public bool AddSavedRecipe(int recipeId)
    {
        // if recipe does not exist
        if (recipes.ContainsKey(recipeId) ==false)
        {
            return false;
        }
        //else if recipe is already been saved
        else if (savedReciepes.Contains(recipeId))
        {

            return false;
        }
        else
        {    
            savedReciepes.Add(recipeId);
            return true;
        }

    }

    public bool RemoveSavedRecipe(int recipeId)
    {
        if (savedReciepes.Contains(recipeId))
        {
            savedReciepes.Remove(recipeId);
            return true;
        }
        else
        {
            Console.WriteLine("The recipe is not saved");
            return false;
        }
    }

    public bool IsRecipeSaved(int recipeId)
    {
        if (savedReciepes.Contains(recipeId))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public IReadOnlyList<int> GetSavedRecipes()
    {
        return savedReciepes.ToList();
    }

}
