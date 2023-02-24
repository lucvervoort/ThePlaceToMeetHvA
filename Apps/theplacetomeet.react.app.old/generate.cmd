REM npx oas-client codegen 
docker run --rm -v %CD%:/local openapitools/openapi-generator-cli generate -i /local/swagger.json -g csharp -o /local/src/generated/csharp
docker run --rm -v %CD%:/local openapitools/openapi-generator-cli generate -i /local/swagger.json -g javascript -o /local/src/generated/javascript
docker run --rm -v %CD%:/local openapitools/openapi-generator-cli generate -i /local/swagger.json -g aspnetcore -o /local/src/generated/aspnetcore
docker run --rm -v %CD%:/local openapitools/openapi-generator-cli generate -i /local/swagger.json -g nodejs-express-server -o /local/src/generated/nodeserver
