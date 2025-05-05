# BlogAPI

A simple RESTful API built with .NET 8 for managing blog posts and comments.

## How to Run

1. **Restore dependencies**
   ```
   dotnet restore
   ```

2. **Apply EF Core Migrations (if applicable)**
   ```
   dotnet ef database update
   ```

3. **Run the project**
   ```
   dotnet run
   ```

4. **Open Swagger UI**
   Navigate to:
   ```
   https://localhost:5001/swagger
   ```

## API Endpoints

- `GET /api/posts`: List all blog posts with comment counts
- `POST /api/posts`: Create a new blog post
- `GET /api/posts/{id}`: Get a specific post and its comments
- `POST /api/posts/{id}/comments`: Add a comment to a post

## Sample Request (Postman/Swagger)

**Create Blog Post**

```json
POST /api/posts
{
  "title": "My Test Blog",
  "content": "This is a test post."
}
```

**Add Comment**

```json
POST /api/posts/1/comments
{
  "authorName": "Mark",
  "content": "Amazing article!"
}
```

## Next Steps (if more time)

- Add authentication
- Add pagination and filtering
- Add more validations
- Add error handling
- Add unit tests for all endpoints
