import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { AdminModule } from './admin/admin.module';
import { AppRoutingModule } from './app.routing';
import { UsuarioComumModule } from './usuario-comum/usuario-comum.module';
import { SharedModule } from './shared/shared.module';
import { HomeComponent } from './home';
import { FooterComponent } from './footer';
import { HeaderComponent } from './header';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MaterialModule } from './angular-material-modules';
import { TopicosModule } from './topicos/topicos.module';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    FooterComponent,
    HeaderComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    AdminModule,
    UsuarioComumModule,
    RouterModule,
    AppRoutingModule,
    SharedModule,
    FlexLayoutModule,
    MaterialModule,
    TopicosModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
