import { NotyfArrayEvent, NotyfNotification } from './notyf.models';
import { NotyfEvent } from './notyf.options';
export declare class NotyfView {
    a11yContainer: HTMLElement;
    animationEndEventName: string;
    container: HTMLElement;
    private notifications;
    private events?;
    private readonly X_POSITION_FLEX_MAP;
    private readonly Y_POSITION_FLEX_MAP;
    constructor();
    on(event: NotyfEvent, cb: (notification: NotyfNotification) => void): void;
    update(notification: NotyfNotification, type: NotyfArrayEvent): void;
    removeNotification(notification: NotyfNotification): void;
    addNotification(notification: NotyfNotification): void;
    private _renderNotification;
    private _popRenderedNotification;
    private getXPosition;
    private getYPosition;
    private adjustContainerAlignment;
    private _buildNotificationCard;
    private _createHTLMElement;
    /**
     * Creates an invisible container which will announce the notyfs to
     * screen readers
     */
    private _createA11yContainer;
    /**
     * Announces a message to screenreaders.
     */
    private _announce;
    /**
     * Determine which animationend event is supported
     */
    private _getAnimationEndEventName;
}
