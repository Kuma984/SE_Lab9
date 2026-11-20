# Dockerfile for Lab 9: Software Testing
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy solution and project files
COPY SE_Lab9_524K0021.sln ./
COPY src/ ./src/
COPY tests/ ./tests/

# Restore dependencies
RUN dotnet restore SE_Lab9_524K0021.sln

# Execute Unit Tests (BasicMath & BankAccount)
RUN dotnet test tests/BasicMathTests/BasicMathTests.csproj --logger "console;verbosity=normal"
RUN dotnet test tests/BankAccountTests/BankAccountTests.csproj --logger "console;verbosity=normal"

# Publish the BasicMath demonstration application
RUN dotnet publish src/BasicMath/BasicMath.csproj -c Release -o /app/publish

# Lean runtime stage
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish ./
ENTRYPOINT ["dotnet", "BasicMath.dll"]
