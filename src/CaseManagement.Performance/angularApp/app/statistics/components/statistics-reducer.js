var __assign = (this && this.__assign) || function () {
    __assign = Object.assign || function(t) {
        for (var s, i = 1, n = arguments.length; i < n; i++) {
            s = arguments[i];
            for (var p in s) if (Object.prototype.hasOwnProperty.call(s, p))
                t[p] = s[p];
        }
        return t;
    };
    return __assign.apply(this, arguments);
};
import { ActionTypes } from './statistics-actions';
var initialStatisticAction = {
    content: null,
    isLoading: true,
    isErrorLoadOccured: false
};
var initialWeekStatisticAction = {
    content: null,
    isLoading: true,
    isErrorLoadOccured: false
};
var initialMonthStatisticAction = {
    content: null,
    isLoading: true,
    isErrorLoadOccured: false
};
var initalDeployedState = {
    isErrorLoadOccured: false,
    isLoading: true,
    content: null
};
export function statisticReducer(state, action) {
    if (state === void 0) { state = initialStatisticAction; }
    switch (action.type) {
        case ActionTypes.STATISTICLOADED:
            var statisticLoadedAction = action;
            state.content = statisticLoadedAction.result;
            state.isLoading = false;
            state.isErrorLoadOccured = false;
            return __assign({}, state);
        case ActionTypes.ERRORLOADSTATISTIC:
            state.isErrorLoadOccured = true;
            state.isLoading = false;
            return __assign({}, state);
        default:
            return state;
    }
}
export function weekStatisticsReducer(state, action) {
    if (state === void 0) { state = initialWeekStatisticAction; }
    switch (action.type) {
        case ActionTypes.WEEKSTATISTICSLOADED:
            var statisticLoadedAction = action;
            state.content = statisticLoadedAction.result;
            state.isLoading = false;
            state.isErrorLoadOccured = false;
            return __assign({}, state);
        case ActionTypes.ERRORWEEKSTATISTICS:
            state.isErrorLoadOccured = true;
            state.isLoading = false;
            return __assign({}, state);
        default:
            return state;
    }
}
export function monthStatisticsReducer(state, action) {
    if (state === void 0) { state = initialMonthStatisticAction; }
    switch (action.type) {
        case ActionTypes.MONTHSTATISTICSLOADED:
            var statisticLoadedAction = action;
            state.content = statisticLoadedAction.result;
            state.isLoading = false;
            state.isErrorLoadOccured = false;
            return __assign({}, state);
        case ActionTypes.ERRORMONTHSTATISTICS:
            state.isErrorLoadOccured = true;
            state.isLoading = false;
            return __assign({}, state);
        default:
            return state;
    }
}
export function deployedReducer(state, action) {
    if (state === void 0) { state = initalDeployedState; }
    switch (action.type) {
        case ActionTypes.DEPLOYEDLOADED:
            var deployedLoadedAction = action;
            state.content = deployedLoadedAction.result;
            state.isLoading = false;
            state.isErrorLoadOccured = false;
            return __assign({}, state);
        case ActionTypes.ERRORLOADDEPLOYED:
            state.isErrorLoadOccured = true;
            state.isLoading = false;
            return __assign({}, state);
        default:
            return state;
    }
}
//# sourceMappingURL=statistics-reducer.js.map