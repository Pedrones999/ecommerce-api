# E-Commerce

## Tabela de conteúdos

- [E-Commerce](#e-commerce)
  - [Tabela de conteúdos](#tabela-de-conteúdos)
  - [Entidades](#entidades)
  - [Funcionalidades](#funcionalidades)
    - [Usuário](#usuário)
    - [Administrador](#administrador)
    - [Rotas](#rotas)

## Entidades

- Usuário
- Administrador
- Produto

## Funcionalidades

### Usuário

- Cadastrar
- Logar
- Listar produtos
- Adicionar produto ao carrinho
- Remover produto do carrinho

### Administrador

- Cadastrar
- Logar
- Listar produtos
- Adicionar produto
- Remover produto
- Editar produtos
- Listar usuários
- Remover usuário
- Editar usuário

### Rotas

- `GET`

  - /products
  - /products/:id
  - **APENAS ADMIN**
    - /users
    - /users/:id

- `POST`

  - /login
  - /register
  - /products

- `PUT` ou `PATCH`

  - /products/:id
  - /users/:id

- `DELETE`

  - /products/:id
  - /users/:id
