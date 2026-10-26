using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using RecipeManagement.Core;

namespace RecipeManagement.Tests;

/// <summary>
/// Example tests from the assignment specification. Add your own tests as you work.
/// </summary>
public sealed class RecipeManagerTests
{
    [Fact]
    public void Constructor_BuildsRecipeDictionary()
    {
        var manager = CreateManager();
        Assert.Equal(2, manager.RecipeCount);
        Assert.Equal("Recipe A", manager.FindRecipe(10)?.Title);
    }

    [Fact]
    public void InstructionsAreCompletedInFileOrder()
    {
        var manager = CreateManager();
        Assert.True(manager.StartCooking(10));
        Assert.Equal("First step", manager.PeekNextInstruction());
        Assert.Equal("First step", manager.CompleteNextInstruction());
        Assert.Equal("Second step", manager.PeekNextInstruction());
    }

    [Fact]
    public void RemovedRecipesAreRestoredLastInFirstOut()
    {
        var manager = CreateManager();
        manager.AddRecipeToCookingPlan(10);
        manager.AddRecipeToCookingPlan(20);
        manager.RemoveRecipeFromCookingPlan(10);
        manager.RemoveRecipeFromCookingPlan(20);
        Assert.Equal(20, manager.PeekLastRemovedRecipe());
        Assert.True(manager.RestoreLastRemovedRecipe());
        Assert.Equal(new[] { 20 }, manager.GetCookingPlan());
    }

    [Fact]
    public void AddIngredientsToShoppingList_AddsOngridients()
    {
        var manager = CreateManager();
        int added = manager.AddIngredientsToShoppingList(10);

        Assert.Equal(1, added);
        Assert.Equal(new[] {"1 apple"}, manager.GetShoppingList());
    }

    [Fact]
    public void ClearShoppingList_Test()
    {
        var manager = CreateManager();

        manager.AddIngredientsToShoppingList(10);
        manager.ClearShoppingList();

        Assert.Empty(manager.GetShoppingList());
    }

    [Fact]
    public void CantAddRecipePlanTwiceTest()
    {
        var manager = CreateManager();

        Assert.True(manager.AddRecipeToCookingPlan(10));
        Assert.False(manager.AddRecipeToCookingPlan(10));
    }

    [Fact]
    public void FindRecipeReturnNullForNoRecipe()
    {
        var manager = CreateManager();

        Assert.Null(manager.FindRecipe(999));
    }

    [Fact]
    public void LastRemoveRecipePeek()
    {
         var manager = CreateManager();

        Assert.Null(manager.PeekLastRemovedRecipe());
    }

    [Fact]
    public void AddRecipeReturnFalseDublicatedIdTest()
    {
        var manager = CreateManager();
        Recipe recipe = new Recipe { Id = 10, Title = "Another Recipe"};

        Assert.False(manager.AddRecipe(recipe));


    }
    //Part B - Search by title test 
    [Fact]
    public void searchByTitleTest()
    {
        var manager = CreateManager();
        var result = manager.SearchByTitle("recipe a");

        Assert.Single(result);
        Assert.Equal(10, result[0].Id);
    }
    // Part B - Search by ingridient 
    [Fact]
    public void searchByIngredientTest()
    {
        var manager = CreateManager();
        var result = manager.SearchByIngredient("APPLE");

        Assert.Single(result);
        Assert.Equal(10, result[0].Id);
    }
    // Part B - Highest protein
    [Fact]
    public void highestProteinTest()
    {
        var manager = CreateManager();
        var result = manager.GetHighestProteinRecipes(2);

        Assert.Empty(result);
    }
    // Part B - Add saved recipe
    [Fact]
    public void addSavedRecipeTest()
    {
        var manager = CreateManager();

        Assert.True(manager.AddSavedRecipe(10));
        Assert.True(manager.IsRecipeSaved(10));
    }
    // Part B - Remove saved recipe
    [Fact]
    public void removeSavedRecipe()
    {
        var manager = CreateManager();

        manager.AddSavedRecipe(10);

        Assert.True(manager.RemoveSavedRecipe(10));
        Assert.False(manager.IsRecipeSaved(10));
        Assert.Empty(manager.GetSavedRecipes());
    }
    // Part B - Integration Test
    [Fact]
public void partBIntegrationTest()
{
    var manager = CreateManager();
    var result = manager.SearchByTitle("Recipe A");
    
    Assert.Single(result);
    Assert.True(manager.AddSavedRecipe(10));
    Assert.True(manager.AddRecipeToCookingPlan(10));
    Assert.True(manager.RemoveSavedRecipe(10));
}

    private static RecipeManager CreateManager()
    {
        return new RecipeManager(new[]
        {
            new Recipe
            {
                Id = 10,
                Title = "Recipe A",
                Ingredients = new() { "1 apple" },
                Instructions = new() { "First step", "Second step" }
            },
            new Recipe
            {
                Id = 20,
                Title = "Recipe B"
            }

        });
    }
}
