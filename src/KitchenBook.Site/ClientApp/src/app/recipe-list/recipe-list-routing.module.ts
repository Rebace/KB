import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {RecipeListPageComponent} from './recipe-list-page/recipe-list-page.component';

const routes: Routes = [
    {
        path: 'recipes',
        component: RecipeListPageComponent,
        children: []
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class RecipeListRoutingModule {
}
