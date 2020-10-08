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
import * as fromActions from '../actions/humantaskdef.actions';
export var initialHumanTaskDefState = {
    content: null,
    isLoading: true,
    isErrorLoadOccured: false
};
export function humanTaskDefReducer(state, action) {
    if (state === void 0) { state = initialHumanTaskDefState; }
    switch (action.type) {
        case fromActions.ActionTypes.COMPLETE_GET_HUMANTASKDEF:
            state.content = action.content;
            return __assign({}, state);
        case fromActions.ActionTypes.COMPLETE_UPDATE_HUMANASKDEF:
            state.content = action.content;
            return __assign({}, state);
        default:
            return state;
    }
}
;
//# sourceMappingURL=humantaskdef.reducers.js.map