# Life simulator

Jogo de decisões em cartas, no estilo Tinder, feito na **Ludum Dare 44** (modo Jam, tema “Your life is currency”) pra provocar hábitos financeiros saudáveis.

- Jogue no navegador: https://will-lucena.com.br/jogos/ld44
- Página na jam: https://ldjam.com/events/ludum-dare/44/life-simulator

![Tela do jogo](https://will-lucena.com.br/img/jogos/ld44.jpg)

## Como rodar

Atualizado para **Unity 6 (6000.6.2f1)** em outubro de 2026. Abra a pasta no Unity Hub com essa versão, ou gere o build pela linha de comando:

```sh
# WebGL (precisa do módulo "Web Build Support")
Unity.exe -batchmode -quit -projectPath . -buildTarget WebGL -executeMethod WebGLBuild.Build
# Windows
Unity.exe -batchmode -quit -projectPath . -buildTarget Win64 -executeMethod WebGLBuild.BuildWindows
```

O build sai em `Builds/`. O script fica em `Assets/Editor/WebGLBuild.cs`.
