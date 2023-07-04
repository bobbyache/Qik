# Design

# Interpreter

![Qik Interpreter](https://www.plantuml.com/plantuml/png/jLF1ReCm3BttAwoUg0Rz05IXJjCwSPnQxJBja89RHGi1nQPgjUtV5s2XfAKxJ1g7G9ndlyUpioGMXkj2mVHPlaEg6KrbqAxJYMmsEv4XfEjJiItLHcmLmcBH7oG9V4p0FdSF2eK9PZ4SIfbteViyxz82Qb-nA-DGNvCH2ZI5r4ADitGOYe7OIBr_VUl2gQvgld6sHduHgiP0da4E4yAXEN9RJ_sJooClPUO-BjGFZ1kNtWE2NQqpbgLUYOnBSxAshFn829GPMV46ZppWlN2e4P0fGJHi6iYYKbYWPl8r_PkAfcpKbtqysfN8Lg4VuzgPYRq92k6lv7rxpenjxtybkrt9EkXDTXHz9bS_wDaudry3bgXpUu6-0G00 "Qik Interpreter")


```csharp
    var interpreter = new Interpreter();
    var terminal = interpreter.Interpret(new FunctionFactory(TestHelpers.StubPluginLoader), string scriptText);
```