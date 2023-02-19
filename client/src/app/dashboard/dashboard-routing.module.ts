import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { Shell } from "../shell/shell";
import { DashboardComponent } from './dashboard.component';

const routes: Routes = [
	Shell.childRoutes([
		{ path: "dashboard", component: DashboardComponent },
	])
];

@NgModule({
	imports: [RouterModule.forChild(routes)],
	exports: [RouterModule],
	providers: []
})
export class DashboardRoutingModule {
	constructor() {
	}
}
