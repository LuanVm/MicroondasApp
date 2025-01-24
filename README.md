# Projeto Micro-ondas Digital

Este projeto tem como objetivo a criação de um sistema digital de micro-ondas utilizando **Windows Forms** e **C#**, com funcionalidades de controle de aquecimento, programação de ciclos de aquecimento e interação com a interface gráfica do usuário. O micro-ondas deve ser capaz de realizar operações como iniciar, pausar, cancelar aquecimentos e configurar programas predefinidos.

## Funcionalidades Implementadas

### 1. **Interface do Usuário**
A interface foi desenvolvida utilizando **Windows Forms** e permite ao usuário:

- **Selecionar o tempo e a potência** para aquecer alimentos.
- **Escolher programas predefinidos** como "Pipoca", "Leite" e "Carnes", que já possuem tempos e potências otimizados.
- **Iniciar, pausar e cancelar** os aquecimentos em tempo real.

### 2. **Lógica de Aquecimento**
A lógica central do micro-ondas é gerenciada pela classe `ControladorMicroondas`, que contém os seguintes métodos principais:

- **IniciarAquecimento(tempo, potencia)**: Inicia um aquecimento personalizado.
- **IniciarProgramaPredefinido(nomePrograma)**: Inicia um programa predefinido baseado no nome do programa.
- **PausarAquecimento()**: Pausa o aquecimento em andamento.
- **CancelarAquecimento()**: Cancela o aquecimento em andamento e limpa o estado atual.

### 3. **SOLID e Design Patterns**
- **Princípios SOLID**: O projeto segue os princípios SOLID, com ênfase na **Responsabilidade Única** e **Segregação de Interfaces**, para garantir que cada classe tenha uma única responsabilidade e que a interface `IControladorMicroondas` seja simples e eficiente.
- **Factory Pattern**: Um padrão de fábrica pode ser aplicado para criar objetos de `Aquecimento` e `ProgramaAquecimento`, facilitando a extensão do sistema com novos tipos de programas.
- **Strategy Pattern**: Poderia ser utilizado para permitir diferentes tipos de algoritmos de aquecimento, dependendo do alimento.
- **Observer Pattern**: Pode ser aplicado para atualizar automaticamente a interface do usuário enquanto o aquecimento está em andamento, notificando quando o tempo de aquecimento muda.

### 4. **Testes Unitários**
Testes unitários foram implementados utilizando o **xUnit** e **Moq**, garantindo a cobertura das funcionalidades principais do sistema:

- **Testes de Aquecimento**: Verificam se o aquecimento é iniciado corretamente e se os tempos e potências são atribuídos corretamente.
- **Testes de Programas Predefinidos**: Asseguram que os programas como "Pipoca" e "Leite" iniciam com os tempos e potências corretas.

#### Exemplos de Testes:

```csharp
[Fact]
public void DeveIniciarAquecimentoCorretamente()
{
    // Arrange
    var controlador = new ControladorMicroondas();

    // Act
    controlador.IniciarAquecimento(30, 5);

    // Assert
    Assert.NotNull(controlador.AquecimentoAtual);
    Assert.Equal(30, controlador.AquecimentoAtual.TempoTotal);
    Assert.Equal(5, controlador.AquecimentoAtual.Potencia);
}
