import {NgModule} from '@angular/core';
import {RecipeListPageComponent} from './recipe-list-page/recipe-list-page.component';
import {RecipeListRoutingModule} from './recipe-list-routing.module';
import {HttpClientModule} from '@angular/common/http';
import {RecipeService} from './recipe.service';
import {BrowserModule} from '@angular/platform-browser';
import {MatCardModule} from '@angular/material/card';
import {RecipeComponent} from './shared/recipe.component/recipe.component';
import {MatSliderModule} from '@angular/material/slider';

@NgModule({
    declarations: [
        RecipeListPageComponent,
        RecipeComponent
    ],
    imports: [
        RecipeListRoutingModule,
        HttpClientModule,
        BrowserModule,
        MatCardModule,
        MatSliderModule,
    ],
    providers: [
        RecipeService
    ]
})

export class RecipeListModule {

}
