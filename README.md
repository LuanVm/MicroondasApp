# Projeto Micro-ondas Digital

Este projeto tem como objetivo a criação de um sistema digital de micro-ondas utilizando **Windows Forms** e **C#**, com funcionalidades de controle de aquecimento, programação de ciclos de aquecimento e interação com a interface gráfica do usuário. O sistema foi projetado para ser intuitivo e atender aos requisitos mínimos e desejáveis propostos para o desafio.

## Funcionalidades Implementadas

### 1. **Interface do Usuário**
A interface foi desenvolvida utilizando **Windows Forms**, permitindo ao usuário:

- **Selecionar o tempo e a potência** para aquecer alimentos de forma personalizada.
- **Escolher programas predefinidos** como "Pipoca", "Leite" e "Carnes", que já possuem tempos, potências e caracteres otimizados para cada tipo de alimento.
- **Iniciar, pausar e cancelar** os aquecimentos em tempo real.
- Exibir o **progresso visual** do aquecimento utilizando caracteres configuráveis.

### 2. **Lógica de Aquecimento**
A lógica central do micro-ondas é gerenciada pela classe `ControladorMicroondas`, que contém os seguintes métodos principais:

- **IniciarAquecimento(tempo, potencia)**: Inicia um aquecimento personalizado com tempo e potência definidos pelo usuário.
- **IniciarProgramaPredefinido(nomePrograma)**: Inicia um programa predefinido com parâmetros otimizados para tipos específicos de alimentos.
- **PausarAquecimento()**: Pausa o aquecimento em andamento, permitindo retomada posterior.
- **CancelarAquecimento()**: Cancela o aquecimento em andamento, limpando o estado atual.

### 3. **Cadastro de Programas Customizados**
O sistema permite que o usuário crie e gerencie programas de aquecimento customizados, com validações específicas:

- **Tempo**: Deve ser entre 1 e 6000 segundos para programas customizados.
- **Potência**: Deve estar entre 1 e 10.
- **Caractere de Aquecimento**: Não pode ser o caractere padrão "." e nem um caractere vazio para programas customizados.

Os programas são armazenados em um arquivo JSON para garantir persistência entre execuções.

### 4. **SOLID e Design Patterns**
- **Princípios SOLID**: O projeto adota os princípios SOLID, com destaque para **Responsabilidade Única** e **Inversão de Dependência**, promovendo um código modular e fácil de manter.
- **Repositório**: A interface `IProgramaRepository` e sua implementação `ProgramaRepository` gerenciam o armazenamento e carregamento de programas customizados.
- **Validações Centralizadas**: Classes utilitárias como `Utilitarios` encapsulam validações comuns, como de tempo e potência.

### 5. **Persistência de Dados**
Os programas customizados são salvos em um arquivo chamado `programas_customizados.json` localizado no diretório da aplicação. Isso garante que as configurações criadas pelo usuário sejam mantidas entre sessões.

### 6. **Testes Unitários**
Testes unitários foram implementados utilizando **MSTest** e **Moq**, garantindo a cobertura das funcionalidades principais do sistema:

- **Testes de Aquecimento**: Verificam se o aquecimento é iniciado e pausado corretamente, bem como a atualização do progresso e conclusão.
- **Testes de Programas Customizados**: Garantem que a validação e persistência de programas personalizados funcionam como esperado.
- **Testes de Programas Predefinidos**: Asseguram que os programas como "Pipoca" e "Leite" iniciam com os parâmetros corretos.

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

[Fact]
public void DeveValidarProgramaCustomizado()
{
    // Arrange
    var programa = new ProgramaAquecimento("Pizza", "Alimentos", 600, 8, '*', "Ideal para pizzas", true);

    // Assert
    Assert.Equal("Pizza", programa.Nome);
    Assert.Equal(600, programa.TempoSegundos);
    Assert.Equal(8, programa.Potencia);
    Assert.Equal('*', programa.CaractereAquecimento);
}
```

## Estrutura de Código

### Principais Classes e Interfaces
- **Aquecimento.cs**: Gerencia o estado e progresso do aquecimento em tempo real.
- **ProgramaAquecimento.cs**: Representa programas de aquecimento, sejam predefinidos ou customizados.
- **ControladorMicroondas.cs**: Controla toda a lógica do micro-ondas, conectando interface e lógica de negócios.
- **IProgramaRepository.cs e ProgramaRepository.cs**: Interface e implementação para persistência de programas customizados.
- **Utilitarios.cs**: Classe de validações reutilizáveis.

---

