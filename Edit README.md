# CQRS + MediatR Example

This repo shows a **simple, hands-on example** of how to use **CQRS (Command Query Responsibility Segregation)** with **MediatR** in C#.  
Think of it as a starter kit — nothing fancy, just enough to understand the pattern without drowning in boilerplate.

---

## Why CQRS?
Instead of mixing "read" and "write" logic together, CQRS says:
- **Commands** = “Do something” (create, update, delete).
- **Queries** = “Give me something” (fetch, read, list).

This separation makes the codebase:
- Easier to **read** and **navigate**  
- Cleaner to **test**  
- Safer to **extend** without breaking stuff  

---

## What’s Inside?
- **Commands** → The requests that change state.  
- **Queries** → The requests that return data.  
- **Handlers** → The brains that process commands/queries.  
- **MediatR** → The glue that connects everything.  

Basically: `Controller → MediatR → Handler → Done ✅`

---

## Project Layout
