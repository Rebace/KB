import {Component, OnInit} from '@angular/core';
import {RecipeService} from '../recipe.service';
import {Recipe} from '../shared/recipe.interface';

@Component({
    selector: 'tl-recipe-list',
    templateUrl: 'recipe-list-page.component.html',
    styleUrls: ['recipe-list-page.component.scss']
})

export class RecipeListPageComponent implements OnInit {
    constructor(private recipeService: RecipeService) {
    }

    public recipes: Array<Recipe> = [];

    public ngOnInit(): void {
        this.recipeService.getAll().subscribe((raw: Recipe[]) => {
            const recipes = <Array<Recipe>>raw;
            recipes.forEach(recipe => {
                this.recipes.push(<Recipe>recipe);
            });
        });
    }
}
