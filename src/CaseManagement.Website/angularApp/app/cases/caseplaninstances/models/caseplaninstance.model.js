var StateHistory = (function () {
    function StateHistory() {
    }
    StateHistory.fromJson = function (json) {
        var result = new StateHistory();
        result.State = json["state"];
        result.DateTime = json["datetime"];
        return result;
    };
    return StateHistory;
}());
export { StateHistory };
var TransitionHistory = (function () {
    function TransitionHistory() {
    }
    TransitionHistory.fromJson = function (json) {
        var result = new TransitionHistory();
        result.Transition = json["transition"];
        result.DateTime = json["datetime"];
        return result;
    };
    return TransitionHistory;
}());
export { TransitionHistory };
var ExecutionHistory = (function () {
    function ExecutionHistory() {
    }
    ExecutionHistory.fromJson = function (json) {
        var result = new ExecutionHistory();
        result.StartDateTime = json["start_datetime"];
        result.EndDateTime = json["end_datetime"];
        result.Id = json["id"];
        return result;
    };
    return ExecutionHistory;
}());
export { ExecutionHistory };
var CasePlanElementInstance = (function () {
    function CasePlanElementInstance() {
        this.StateHistories = [];
        this.TransitionHistories = [];
    }
    CasePlanElementInstance.fromJson = function (json) {
        var result = new CasePlanElementInstance();
        result.Id = json["id"];
        result.Version = json["version"];
        result.CreateDateTime = json["create_datetime"];
        result.DefinitionId = json["definition_id"];
        result.FormInstanceId = json["form_instanceid"];
        result.State = json["state"];
        json["state_histories"].forEach(function (sh) {
            result.StateHistories.push(StateHistory.fromJson(sh));
        });
        json["transition_histories"].forEach(function (th) {
            result.TransitionHistories.push(TransitionHistory.fromJson(th));
        });
        return result;
    };
    return CasePlanElementInstance;
}());
export { CasePlanElementInstance };
var CasePlanInstance = (function () {
    function CasePlanInstance() {
        this.StateHistories = [];
        this.TransitionHistories = [];
        this.ExecutionHistories = [];
        this.Elements = [];
    }
    CasePlanInstance.fromJson = function (json) {
        var result = new CasePlanInstance();
        result.Id = json["id"];
        result.CreateDateTime = json["create_datetime"];
        result.DefinitionId = json["definition_id"];
        result.Context = json["context"];
        result.State = json["state"];
        json["state_histories"].forEach(function (sh) {
            result.StateHistories.push(StateHistory.fromJson(sh));
        });
        json["transition_histories"].forEach(function (th) {
            result.TransitionHistories.push(TransitionHistory.fromJson(th));
        });
        json["execution_histories"].forEach(function (eh) {
            result.ExecutionHistories.push(ExecutionHistory.fromJson(eh));
        });
        json["elements"].forEach(function (elt) {
            result.Elements.push(CasePlanElementInstance.fromJson(elt));
        });
        return result;
    };
    return CasePlanInstance;
}());
export { CasePlanInstance };
//# sourceMappingURL=caseplaninstance.model.js.map