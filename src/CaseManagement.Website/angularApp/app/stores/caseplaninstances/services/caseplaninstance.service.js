var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';
var CasePlanInstanceService = (function () {
    function CasePlanInstanceService(http, oauthService) {
        this.http = http;
        this.oauthService = oauthService;
    }
    CasePlanInstanceService.prototype.search = function (startIndex, count, order, direction, casePlanId) {
        var headers = new HttpHeaders();
        headers = headers.set('Accept', 'application/json');
        headers = headers.set('Content-Type', 'application/json');
        headers = headers.set('Authorization', 'Bearer ' + this.oauthService.getIdToken());
        var targetUrl = process.env.API_URL + "/case-plan-instances/search";
        var request = { startIndex: startIndex, count: count };
        if (order) {
            request["orderBy"] = order;
        }
        if (direction) {
            request["order"] = direction;
        }
        if (casePlanId) {
            request["casePlanId"] = casePlanId;
        }
        return this.http.post(targetUrl, request, { headers: headers });
    };
    CasePlanInstanceService.prototype.get = function (casePlanInstanceId) {
        var headers = new HttpHeaders();
        headers = headers.set('Accept', 'application/json');
        headers = headers.set('Authorization', 'Bearer ' + this.oauthService.getIdToken());
        var targetUrl = process.env.API_URL + "/case-plan-instances/" + casePlanInstanceId;
        return this.http.get(targetUrl, { headers: headers });
    };
    CasePlanInstanceService.prototype.createCasePlanInstance = function (casePlanId) {
        var headers = new HttpHeaders();
        headers = headers.set('Accept', 'application/json');
        headers = headers.set('Content-Type', 'application/json');
        headers = headers.set('Authorization', 'Bearer ' + this.oauthService.getIdToken());
        var targetUrl = process.env.API_URL + "/case-plan-instances";
        var request = { casePlanId: casePlanId };
        return this.http.post(targetUrl, request, { headers: headers });
    };
    CasePlanInstanceService.prototype.launchCasePlanInstance = function (casePlanInstanceId) {
        var headers = new HttpHeaders();
        headers = headers.set('Accept', 'application/json');
        headers = headers.set('Authorization', 'Bearer ' + this.oauthService.getIdToken());
        var targetUrl = process.env.API_URL + "/case-plan-instances/" + casePlanInstanceId + "/launch";
        return this.http.get(targetUrl, { headers: headers });
    };
    CasePlanInstanceService.prototype.enable = function (casePlanInstanceId, casePlanElementInstanceId) {
        var headers = new HttpHeaders();
        headers = headers.set('Accept', 'application/json');
        headers = headers.set('Authorization', 'Bearer ' + this.oauthService.getIdToken());
        var targetUrl = process.env.API_URL + "/case-plan-instances/" + casePlanInstanceId + "/activate/" + casePlanElementInstanceId;
        return this.http.get(targetUrl, { headers: headers });
    };
    CasePlanInstanceService.prototype.closeCasePlanInstance = function (casePlanInstanceId) {
        var headers = new HttpHeaders();
        headers = headers.set('Accept', 'application/json');
        headers = headers.set('Authorization', 'Bearer ' + this.oauthService.getIdToken());
        var targetUrl = process.env.API_URL + "/case-plan-instances/" + casePlanInstanceId + "/close";
        return this.http.get(targetUrl, { headers: headers });
    };
    CasePlanInstanceService.prototype.reactivateCasePlanInstance = function (casePlanInstanceId) {
        var headers = new HttpHeaders();
        headers = headers.set('Accept', 'application/json');
        headers = headers.set('Authorization', 'Bearer ' + this.oauthService.getIdToken());
        var targetUrl = process.env.API_URL + "/case-plan-instances/" + casePlanInstanceId + "/reactivate";
        return this.http.get(targetUrl, { headers: headers });
    };
    CasePlanInstanceService.prototype.resumeCasePlanInstance = function (casePlanInstanceId) {
        var headers = new HttpHeaders();
        headers = headers.set('Accept', 'application/json');
        headers = headers.set('Authorization', 'Bearer ' + this.oauthService.getIdToken());
        var targetUrl = process.env.API_URL + "/case-plan-instances/" + casePlanInstanceId + "/resume";
        return this.http.get(targetUrl, { headers: headers });
    };
    CasePlanInstanceService.prototype.suspendCasePlanInstance = function (casePlanInstanceId) {
        var headers = new HttpHeaders();
        headers = headers.set('Accept', 'application/json');
        headers = headers.set('Authorization', 'Bearer ' + this.oauthService.getIdToken());
        var targetUrl = process.env.API_URL + "/case-plan-instances/" + casePlanInstanceId + "/suspend";
        return this.http.get(targetUrl, { headers: headers });
    };
    CasePlanInstanceService.prototype.terminateCasePlanInstance = function (casePlanInstanceId) {
        var headers = new HttpHeaders();
        headers = headers.set('Accept', 'application/json');
        headers = headers.set('Authorization', 'Bearer ' + this.oauthService.getIdToken());
        var targetUrl = process.env.API_URL + "/case-plan-instances/" + casePlanInstanceId + "/terminate";
        return this.http.get(targetUrl, { headers: headers });
    };
    CasePlanInstanceService = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [HttpClient, OAuthService])
    ], CasePlanInstanceService);
    return CasePlanInstanceService;
}());
export { CasePlanInstanceService };
//# sourceMappingURL=caseplaninstance.service.js.map