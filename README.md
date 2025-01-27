# Projeto Micro-ondas Digital

Este projeto tem como objetivo a criação de um sistema digital de micro-ondas utilizando Windows Forms e C#, com funcionalidades de controle de aquecimento, programação de ciclos de aquecimento e interação com a interface gráfica do usuário. O sistema foi projetado para ser intuitivo e atender aos requisitos mínimos e desejáveis propostos para o desafio.

## Funcionalidades Implementadas

### 1. Interface do Usuário
A interface foi desenvolvida utilizando Windows Forms, permitindo ao usuário:

- Selecionar o tempo e a potência para aquecer alimentos de forma personalizada.
- Escolher programas predefinidos como "Pipoca", "Leite", "Carnes", "Frango" e "Feijão", que já possuem tempos, potências e caracteres otimizados para cada tipo de alimento.
- Iniciar, pausar e cancelar os aquecimentos em tempo real.
- Início rápido: Adiciona 30 segundos ao tempo restante do aquecimento atual ou inicia um novo aquecimento de 30 segundos na potência máxima.
- Criar e gerenciar programas customizados com tempos, potências e caracteres específicos.
- Exibir o progresso visual do aquecimento utilizando caracteres configuráveis.

### 2. Lógica de Aquecimento
A lógica central do micro-ondas é gerenciada pela classe `ControladorMicroondas`, que contém os seguintes métodos principais:

- `IniciarAquecimento(tempo, potencia)`: Inicia um aquecimento personalizado com tempo e potência definidos pelo usuário.
- `IniciarProgramaPredefinido(nomePrograma)`: Inicia um programa predefinido com parâmetros otimizados para tipos específicos de alimentos.
- `IniciarProgramaCustomizado(nomePrograma)`: Inicia um programa customizado criado pelo usuário.
- `PausarAquecimento()`: Pausa o aquecimento em andamento, permitindo retomada posterior.
- `CancelarAquecimento()`: Cancela o aquecimento em andamento, limpando o estado atual.

### 3. Cadastro de Programas Customizados
O sistema permite que o usuário crie e gerencie programas de aquecimento customizados, com validações específicas:

- **Tempo**: Deve ser entre 1 e 6000 segundos para programas customizados.
- **Potência**: Deve estar entre 1 e 10.
- **Caractere de Aquecimento**: Não pode ser o caractere padrão `.` e nem um caractere vazio para programas customizados.
- **Nome do Programa**: Deve ser único, não podendo repetir nomes de programas já existentes.

Os programas são armazenados em um arquivo JSON (`programas_customizados.json`) para garantir persistência entre execuções.

### 4. SOLID e Design Patterns
**Princípios SOLID**: O projeto adota os princípios SOLID, com destaque para Responsabilidade Única e Inversão de Dependência, promovendo um código modular e fácil de manter.

**Repositório**: A interface `IProgramaRepository` e sua implementação `ProgramaRepository` gerenciam o armazenamento e carregamento de programas customizados.

**Validações Centralizadas**: Classes utilitárias como `Utilitarios` encapsulam validações comuns, como de tempo e potência.

### 5. Persistência de Dados
Os programas customizados são salvos em um arquivo chamado `programas_customizados.json` localizado no diretório da aplicação. Isso garante que as configurações criadas pelo usuário sejam mantidas entre sessões.

## Estrutura de Código
### Principais Classes e Interfaces
- **Aquecimento.cs**: Gerencia o estado e progresso do aquecimento em tempo real.
- **ProgramaAquecimento.cs**: Representa programas de aquecimento, sejam predefinidos ou customizados.
- **ControladorMicroondas.cs**: Controla toda a lógica do micro-ondas, conectando interface e lógica de negócios.
- **IProgramaRepository.cs e ProgramaRepository.cs**: Interface e implementação para persistência de programas customizados.
- **Utilitarios.cs**: Classe de validações reutilizáveis.

---

