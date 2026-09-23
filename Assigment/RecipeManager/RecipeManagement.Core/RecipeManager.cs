using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

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
        

    public RecipeManager(IEnumerable<Recipe> recipes)
    {
        // TODO Part A: validate recipes and build Dictionary<int, Recipe>.

        foreach (Recipe recipe in recipes)
        {
            AddRecipe(recipe);
        }

    }

    public int RecipeCount => 0;
    public int ShoppingItemCount => 0;
    public int CookingPlanCount => 0;
    public int PendingInstructionCount => 0;
    public int RemovedRecipeCount => 0;

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
        if(recipes.ContainsKey(recipeId))
            {
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
        return shoppingList;
    }

    public void ClearShoppingList()
    {
        shoppingList.Clear();
    }

    public bool AddRecipeToCookingPlan(int recipeId)
    {
        if(recipes.ContainsKey (recipeId))
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


    public bool RemoveRecipeFromCookingPlan(int recipeId)
    {

        if (cookingPlan.Contains(recipeId))
        {
            return false;
        }

        cookingPlan.Remove(recipeId);
        removeRecipes.Push(recipeId);
        return true;
    }

    public bool RestoreLastRemovedRecipe()
    {
        if (removeRecipes.Count == 0)
        {
            return false;
        }

        int recipeId = removeRecipes.Pop();

        if (recipes.ContainsKey(recipeId))
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
        
        if (recipe.Ingredients.Count == 0)
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

    public IReadOnlyList<Recipe> SearchByTitle(string searchText) =>
        throw new NotImplementedException("Part B: implement SearchByTitle.");

    public IReadOnlyList<Recipe> SearchByIngredient(string searchText) =>
        throw new NotImplementedException("Part B: implement SearchByIngredient.");

    public IReadOnlyList<Recipe> GetHighestProteinRecipes(int count) =>
        throw new NotImplementedException("Part B: implement GetHighestProteinRecipes.");

    public bool AddSavedRecipe(int recipeId) =>
        throw new NotImplementedException("Part B: implement AddSavedRecipe.");

    public bool RemoveSavedRecipe(int recipeId) =>
        throw new NotImplementedException("Part B: implement RemoveSavedRecipe.");

    public bool IsRecipeSaved(int recipeId) =>
        throw new NotImplementedException("Part B: implement IsRecipeSaved.");

    public IReadOnlyList<int> GetSavedRecipes() =>
        throw new NotImplementedException("Part B: implement GetSavedRecipes.");

}
