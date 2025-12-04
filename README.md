# Simulador de Cargas em Caminhões

Este projeto é um sistema desenvolvido para simular o transporte de cargas por caminhões, considerando limites de peso, distância máxima suportada, prioridades de entrega e cálculo automático do melhor percurso utilizando o algoritmo de **Dijkstra**.

O sistema segue a arquitetura:

**Controllers → Services → Repositories → Models**

com acesso ao banco de dados via **Dapper** e MySQL.

## Funcionalidades

- Cadastro de caminhões  
- Cadastro de cargas  
- Associação de cargas a caminhões disponíveis  
- Cálculo de percursos no mapa  
- Simulação do envio de múltiplas cargas  
- Identificação do menor caminho entre pontos usando Dijkstra  
- API organizada seguindo boas práticas (DTOs, Services, Repositories)

## Tecnologias Utilizadas

- **C# .NET 8**  
- **Dapper**  
- **MySQL** 

## Estrutura do Projeto

```bash
Simulador_de_Cargas_em_Caminhoes/
│
├── Controllers/
├── Services/
├── Repositories/
├── DTOs/
├── Models/
├── Algoritmos/  # (ex.: Dijkstra)
└── appsettings.json
