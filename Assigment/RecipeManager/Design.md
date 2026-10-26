# Design

Complete this document for **Part B**.

## 1. Saved recipe collection
for the saved recipe feature List<int> has been used to store the recipes IDs.The recipe id was used because each recipe already has its own ID. Before adding a recipe I check if the ID is already in the List, this stops the same recipe from being saved more than once.

## 2. Integration

The new Part B features use the existing Part A `RecipeManager` and recipe catalogue that was already creted in part A. The title search, ingredient search and highest protein feature all use the existing recipes Dictionary to find and sort recipes. The saved recipe feature uses a separate List<int>, but it still checks the main recipe catalogue to make sure the recipe ID exists before it can be saved.

## 3. Basic complexity

| Operation | Structure | Expected complexity | Reason |
| --- | --- | --- | --- |
| Lookup recipe by ID | Dictionary | Average O(1) | Hash-based key lookup. |
| Traverse cooking plan | LinkedList | O(n) | Each planned recipe may need to be visited. |
| Complete next instruction | Queue | O(1) | The item at the front is removed. |
| LINQ title/ingredient search | Recipe collection | O(n) | Each recipe may need to be inspected. |
| Check whether a recipe is saved | List | O(n) |The List checks each saved recipe ID using Contains() until it finds a match. |
