Sistema da Máquina do restaurante:

- API será usada pelo cliente e pelo restaurante

- Cliente (pelo app)
  - Cadastro
  - Acesso ao Menu
  - Acompanhamento do status da refeição

- Restaurante (pelo admin)
  - login de admin
  - Cadastro de Pratos
  - Cadastro de Ingredientes
  - Cadastro de usuário
  - Pedido para um usuário específico
  - Pagamento
  
- Regras Gerais
  Fluxo do Cliente
  - Cliente pode fazer cadastro pelo App
  -> Cliente com cadastro tem desconto de 10%
  - Cliente acessa o menu pelo app e só faz o pedido pelo restaurante
  - Cliente acompanha o pedido pela tela de pedido
  - Ao entrar na tela de acomp., o sistema pede o CPF
  - Preço do prato é a soma do valor dos ingredients * 2

  Fluxo do Restaurante
  - Garçom anota o pedido do cliente (prato e quantidade)
  - Garçom pergunta se cliente quer cadastro
  - Garçom confirma o pedido com o cadastro do cliente (se houver)  
  - Formas de Pagamento: |verificar teste de pagamento|
  
Lista de Contextos:
- login
- usuario
- pedidos
- pratos
- ingredientes
- pagamento

---------------------------------------------------------------

Controllers:

- Rotas login: 
POST -> site/login - Login
GET -> site/logout - Logout

- Rotas users:
GET -> /users/{id} - Pega info do user logado
POST -> /users - Criação do user
DELETE -> /users - Deletar user

- Rotas pratos:
GET -> /dishes - Pega info do menu
GET -> /dishes/{id} - pega info do prato
POST -> /dishes - cadastra pratos
PUT -> /dishes/{id} - update de prato
DELETE -> /dishes/{id} - delete de prato

- Ingredients:
POST -> /ingredients/{id} - cadastra ingrediente
DELETE -> /ingredients/{id} - deleta ingrediente

- Rotas pedidos:
GET -> /orders
GET -> /order/{id}
POST -> /order
PUT -> /order/{id}
PUT -> /order/{id}/status

- Rotas Pagamento:
GET -> /payments
GET -> /payments/{orderId}

Banco de Dados:

Tabela: Users
Colunas:
- Id
- Name
- CPF
- Password
- IsAdmin
- IsActive

Tabela: Order
Colunas:
- Id
- UserId
- Value
- Status

OrderDishes
- OrderId
- DishesId

Tabela: Dishes
Colunas:
- Id
- Name
- Value
- IsActive

Tabela: Ingredients_for_Dishes
Colunas:
id Dish
id Ingredient

Tablea: Ingredients
Colunas:
- Id
- Name
- Value
- IsActive