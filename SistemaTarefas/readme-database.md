# Instruções de utilização e instalação da base de dados

## Base de Dados com Docker

- Instalar base de dados PostgreSQL. A base de dados criada tem como url **localhost:5432**, o username é **es2** e a password é **es2**. Poderão usar ferramentas como o [Datagrip](https://www.jetbrains.com/datagrip), [DBeaver](https://dbeaver.io/) ou [pgAdmin](https://www.pgadmin.org/) para aceder diretamente à base de dados.
> docker run --name es2-db -p 5432:5432 -e POSTGRES_PASSWORD=es2 -e POSTGRES_USER=es2 -e POSTGRES_DB=es2 -d postgres

- Para desligar a base de dados
> docker stop es2-db

- Recomeçar a base de dados
> docker start es2-db

- Apagar a base de dados, removendo o container do Docker. **Atenção:** Todos os dados serão apagados.
> docker rm es2-db
