# Ducking

- All the project dependencies across the examples are the same
- Ugh, lots of things
- Q: How to use service locator when we do not have access to outside dependencies?
    - 

## Designing

Q: Should the service locator be a separate service, or exist within the order service project?
- It is a pattern the OrderService uses to encapsulate dependencies. It should be its own service.

Q: How does the constructor injection example satisfy 

### What each service should know of
OrderService:
- its interfaces and the service locator 
ServiceLocator:
- Interfaces and outer dependencies
Outer dependencies (notification, shipping):
- nothing about service locator or order service

### Branch notes
- Added webapi project to make example more realistic
- Emphasis on dependencies found in each csproj file (breakdown in section "What each service should know of" in this document)
- Emphasis on constructor injection of class dependencies
- TODO: Add wiring to configure services for WebAPI DI Container
    - If attempt to call API, fails with the error message, "Unable to resolve service for type 'Interfaces.IOrderService' while attempting to activate 'OrderApi.Controllers.WeatherForecastController'." 
- The stratification of the solution is as follows
    - API Layer: OrderAPI
    - Service Layer: OrderService
    - Interfaces project exists as contracts for connection between layers or dependencies of layers
- Dependencies of solutions:
    - service locator: acts as the dependency management container for the solution
    - notification service
    - shipping service