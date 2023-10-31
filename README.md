# Dependency injection example

## Motivation
- Create an example of dependency injection from work for discussion in class of what is done well and what can be improved.
- understand toolbox of common injection approaches
- understand how inversion is different and why it matters
- understand the main ways injection can fail to deliver value and why

## Requirements
- Further identify the responsibility of the OrderService
    - Order booking
    - Order sourcing/planning
    - Changes to the order

## Desired focus
- Build upon discussion of previous week, keeping in mind that OrderService acts as one piece of an order fulfillment system
- Implement dependency inversion at a class level

## Ducking
- What are the various business concerns of the order fulfillment process? source: [Wikipedia](https://en.wikipedia.org/wiki/Order_fulfillment)
    - Order booking
    - Order acknowledgment/confirmation
    - Invoicing (or billing)
    - Order sourcing/planning
    - Changes to order
    - Processing of order (warehouse fulfills order)
    - Shipment
    - Tracking of order goods
    - Delivery
    - Settlement
    - Returns
- What concerns will the OrderService own in the order fulfillment process?
    - Order booking
        - Formal booking of an order by a customer (customer stating that they want to purchase items by click of "Purchase" button upon completing billing and shipping information)
    - Changes to order
        - Modify an order if changes are made by the user
    - Returns
        - Reclassifying the items as part of the business' inventory
- Order fulfillment concerns that are outside of the OrderService
    - Acknowledgement/confirmation
    - Invoicing
    - Processing/shipment
    - Tracking
    - Delivery
    - Settlement
- Order processing and shipment sound particularly similar to me, so I decided to lump them together for the sake of this exercise
- How does the callee know about the abstraction created by the caller?
    - Say order service and shipping service are two separate repos
- Shipping service doesn't know it is fulfilling orders, doesn't know that it is part of an ecommerce chain, just know it has to deal with shipping stuff
- REQ: Don't want shipping service to know about order service and vice versa
    - Q: How do we get shipping service to "do its thing" (plan/source, ship, track, and deliver) for us?
        - Scenario 1: Order service publish event order booked, Shipping service subscribes to event, fires off call to get order information
            - Problem: shipping service now knows it is part of an order fulfillment service by two points:
                - listening to events now becomes part of the shipping service's concerns
                    - now a shipping/event listening service (violates srp)
                - calling a particular table (violates information hiding)
        - Scenario 2: Order service calls a "shipping service" via service locator to conduct shipping
            - Why is service locator toxic and violate information hiding?
                - Creating a file that defines a relationship between an abstraction created by order service and the current service to resolve that abstraction to just makes the same problem look different
                - adding more layers without solving anything
        - Mutual dependency exists both ways. Question is, how do we reduce that as much as possible?
            - Versioning removes the dependency of order service on any further development



## Outside services that exist for the sake of discussion
### Shipping Service
- Owns:
    - Shipment
    - Tracking
    - Delivery
    - shipment sourcing/planning
### Financial Service
- Owns:
    - Invoicing/billing
    - Settlement
### Notification service
- Owns:
    - Acknowledgement/confirmation

## My questions/curiosities to discuss
- My motivation for picking the particular responsibilities of the order service that I chose was for a concern of the items being purchased. I envisioned the order service at its most essential functionality to be concerned with the sourcing allocation of items picked by the customer. However, once we have found the items a customer wants, that is outside of the scope of the system. At that point, we will pass along an order plan via an API to the warehouse where maybe we post an event detailing that we have a new order plan to fulfill.
- Curiosity: In the scenario where a notification that a "Order plan" has been created is posted as some sort of event, who owns the abstraction for what is sent from the system that has the order plan to the system who is requesting the order plan?
    - ShippingService (caller) is calling OrderService (callee), asking for new order plans
        - Does ShippingService own the abstraction for an API?
- Curiosity: say shipping service and order service are two separate repos. How does shipping service, as the caller, let the order service know of the abstraction it has created for some method that returns order information? That way, shipping service at compile time is determining what the order service (or whatever information resource responsible for order information) is sending back. How is the order service aware of the abstraction that the shipping service created and is, as a result, dependent upon?
