## Information
- Strong typing example of service locator can be found in StrongExample.cs
- Generic typing example of service locator can be found in GenericExample.cs
- For the sake of this exercise, we will pretend main is part of the order service and is dependent upon functionality in return service and update service

## Questions

### What ways exist to implement the service locator design pattern in a system?
- Strong type
- Generic type

### How does the service locator pattern satisfy the "Dependency Inversion" principle of SOLID?

- Example classes no longer depend directly on the service class they need. Now they just get the type of dependency they need from the service locator

### How does the service locator pattern not satisfy the "Dependency Inversion" principle of SOLID?

- main classes now dependent on respective service locator class, which is dependent on classes strongly typed with IService or listed out in 

## Ducking
- [CSharp Corner Service locator example article](https://www.c-sharpcorner.com/UploadFile/dacca2/service-locator-design-pattern/)
- GOAL: keep each example in line with the OrderService problem domain
- Treating order service as the repo name, no longer a class name
- Q: How to decouple low level implementation (service classes responsible for management of returns and order updates) from high level concerns (requirements)
- SMELL: service class names contain requirements information
- commonly see the line "abstracts all the complexities"
- seems to vary in complexity [J2EE](https://www.oracle.com/java/technologies/service-locator.html)
- Q: Does the service locator pattern implement calls to a service locator from client-side? API Controller uses service locator? Assumption is yes

## Analysis of example

- Discussion:

- What is done well with this example?
- What can be improved upon?
- What was missed in this pattern breakdown?