var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { animate, state, style, transition, trigger } from '@angular/animations';
import { Component, ViewEncapsulation, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { JwksValidationHandler, OAuthService } from 'angular-oauth2-oidc';
import { authConfig } from './auth.config';
import { SidenavService } from './shared/SidenavService';
import { MatSidenav } from '@angular/material';
var AppComponent = (function () {
    function AppComponent(route, translate, oauthService, router, sidenavService) {
        this.route = route;
        this.translate = translate;
        this.oauthService = oauthService;
        this.router = router;
        this.sidenavService = sidenavService;
        this.isConnected = false;
        this.url = process.env.BASE_URL + "assets/images/logo.png";
        this.casesExpanded = false;
        this.humanTasksExpanded = false;
        this.bpmnsExpanded = false;
        translate.setDefaultLang('fr');
        translate.use('fr');
        this.configureAuth();
    }
    AppComponent.prototype.chooseLanguage = function (evt, lng) {
        evt.preventDefault();
        this.translate.use(lng);
    };
    AppComponent.prototype.login = function (evt) {
        evt.preventDefault();
        this.oauthService.customQueryParams = {
            'prompt': 'login'
        };
        this.oauthService.initImplicitFlow();
        return false;
    };
    AppComponent.prototype.chooseSession = function (evt) {
        evt.preventDefault();
        this.oauthService.customQueryParams = {
            'prompt': 'select_account'
        };
        this.oauthService.initImplicitFlow();
        return false;
    };
    AppComponent.prototype.disconnect = function (evt) {
        evt.preventDefault();
        this.oauthService.logOut();
        this.router.navigate(['/home']);
        return false;
    };
    AppComponent.prototype.toggleCases = function () {
        this.casesExpanded = !this.casesExpanded;
    };
    AppComponent.prototype.toggleHumanTasks = function () {
        this.humanTasksExpanded = !this.humanTasksExpanded;
    };
    AppComponent.prototype.toggleBpmnFiles = function () {
        this.bpmnsExpanded = !this.bpmnsExpanded;
    };
    AppComponent.prototype.init = function () {
        var claims = this.oauthService.getIdentityClaims();
        if (!claims) {
            this.isConnected = false;
            ;
            return;
        }
        this.name = claims.given_name;
        this.roles = claims.role;
        this.isConnected = true;
    };
    AppComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.init();
        this.oauthService.events.subscribe(function (e) {
            if (e.type === "logout") {
                _this.isConnected = false;
            }
            else if (e.type === "token_received") {
                _this.init();
            }
        });
        this.router.events.subscribe(function (opt) {
            var url = opt.urlAfterRedirects;
            if (!url || _this.humanTasksExpanded || _this.casesExpanded) {
                return;
            }
            if (url.startsWith('/cmmns')) {
                _this.casesExpanded = true;
            }
            if (url.startsWith('/humantasks')) {
                _this.humanTasksExpanded = true;
            }
            if (url.startsWith('/bpmns')) {
                _this.bpmnsExpanded = true;
            }
        });
        this.sidenavService.setSidnav(this.sidenav);
    };
    AppComponent.prototype.configureAuth = function () {
        this.oauthService.configure(authConfig);
        this.oauthService.setStorage(localStorage);
        this.oauthService.tokenValidationHandler = new JwksValidationHandler();
        var self = this;
        this.oauthService.loadDiscoveryDocumentAndTryLogin({
            disableOAuth2StateCheck: true
        });
        this.sessionCheckTimer = setInterval(function () {
            if (!self.oauthService.hasValidIdToken()) {
                self.oauthService.logOut();
                self.route.navigate(["/"]);
            }
        }, 3000);
    };
    __decorate([
        ViewChild('sidenav'),
        __metadata("design:type", MatSidenav)
    ], AppComponent.prototype, "sidenav", void 0);
    AppComponent = __decorate([
        Component({
            selector: 'app-component',
            templateUrl: './app.component.html',
            styleUrls: [
                './app.component.scss',
                '../../node_modules/leaflet/dist/leaflet.css',
                '../../node_modules/leaflet-search/dist/leaflet-search.src.css',
                '../../node_modules/cmmn-js/dist/assets/diagram-js.css',
                '../../node_modules/cmmn-js/dist/assets/cmmn-font/css/cmmn.css',
                '../../node_modules/cmmn-js/dist/assets/cmmn-font/css/cmmn-codes.css',
                '../../node_modules/cmmn-js/dist/assets/cmmn-font/css/cmmn-embedded.css',
                '../../node_modules/bpmn-js/dist/assets/diagram-js.css',
                '../../node_modules/bpmn-js/dist/assets/bpmn-font/css/bpmn.css',
                '../../node_modules/bpmn-js/dist/assets/bpmn-font/css/bpmn-codes.css',
                '../../node_modules/bpmn-js/dist/assets/bpmn-font/css/bpmn-embedded.css'
            ],
            encapsulation: ViewEncapsulation.None,
            animations: [
                trigger('indicatorRotate', [
                    state('collapsed', style({ transform: 'rotate(0deg)' })),
                    state('expanded', style({ transform: 'rotate(180deg)' })),
                    transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4,0.0,0.2,1)')),
                ])
            ]
        }),
        __metadata("design:paramtypes", [Router, TranslateService, OAuthService, Router,
            SidenavService])
    ], AppComponent);
    return AppComponent;
}());
export { AppComponent };
//# sourceMappingURL=app.component.js.map