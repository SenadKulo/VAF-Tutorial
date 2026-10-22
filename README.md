# Vision Automation Framework — tutorial code

[![Tests](https://github.com/SenadKulo/VAF-Tutorial/actions/workflows/tests.yml/badge.svg)](https://github.com/SenadKulo/VAF-Tutorial/actions/workflows/tests.yml)

The code of the [VAF tutorials](https://www.visionautomationframework.com/tutorials): one project that
grows lesson by lesson, from the first test of the Quick start to a small suite with page objects,
shared steps and reports. Every test runs against the
[practice pages](https://www.visionautomationframework.com/practice), pages made for test automation.

Each lesson ends in a tag. If your code does not work, compare it with the tag of the lesson:

| Lesson | Tag | What the project has at the end of it |
|---|---|---|
| 1 — [Your first test](https://www.visionautomationframework.com/quick-start-guide) | [`lesson-1`](https://github.com/SenadKulo/VAF-Tutorial/tree/lesson-1) | The Quick start: one test that opens the sign-up form and checks the title |

```
git clone https://github.com/SenadKulo/VAF-Tutorial.git
cd VAF-Tutorial
git checkout lesson-1
```

## Run

Requirements: the [.NET 10 SDK](https://dotnet.microsoft.com/download) and Google Chrome. Selenium
downloads the matching ChromeDriver on the first run.

```
dotnet test
```

or **Test → Run All Tests** in Visual Studio 2026. The project is what Visual Studio's *NUnit Test
Project* template creates (.NET 10, NUnit 4) plus the VAF package; for .NET Framework, set
`<TargetFramework>net472</TargetFramework>`.

To run without a window: `$env:VAF_ChromeArguments = "--headless=new --window-size=1920,1080"; dotnet test`
(PowerShell).

## More

- [VAF-Demo](https://github.com/SenadKulo/VAF-Demo) — tests of every practice page, in three levels.
- [Guide](https://www.visionautomationframework.com/guide) — how a VAF suite is built.

MIT License.
