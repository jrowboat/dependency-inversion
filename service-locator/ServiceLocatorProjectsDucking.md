## Problems
- Shipping and Notification Service are both injected with interfaces from the interface project owned by the OrderService entity

## Ducking
- seeking to setup projects in such a way that hides inner workings of notification service and shipping service from respective order service examples
- REQ: Dependencies of order service should not know about the interfaces used by order service. Service locator should know about the interfaces, but anything else should not know.
- Shared is representative of all dependencies that the OrderService class would be using.
- Outside dependencies should not know about interfaces
- Q: How to explicitly type dependency registered?
    - Typing works when the dependency is typed via Interface Injection, but does not work when service locator owned by order service tries to type NotificationService as our interface type
    - Need help working through this