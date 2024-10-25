use AULADB
go

create table tbPizza(id int not null primary key identity (1,1), descricao varchar(100) not null )
go

create table tbIngredientesPizza (id int not null primary key identity (1,1),  pizzaId  int not null, descricao varchar(100) not null )
go

create or alter procedure sp_delete(
	@id int,
	@tabela varchar(max)
)
as
begin
	declare @sql varchar(max)
	set @sql = 'delete ' + @tabela + ' where id = ' + cast( @id as varchar(max))
	exec(@sql)
end
go

create or alter procedure sp_select(
	@id int,
	@tabela varchar(max)
)
as
begin
	declare @sql varchar(max)
	set @sql = 'select * from  ' + @tabela + ' where id = ' + cast( @id as varchar(max))
	exec(@sql)
end
go

create or alter procedure sp_list(
	@tabela varchar(max)
)
as
begin
	declare @sql varchar(max)
	set @sql = 'select * from  ' + @tabela
	exec(@sql)
end
go

create or alter procedure sp_insert_tbPizza(
	@descricao varchar(max)
)
as
begin
	insert into tbPizza values (@descricao)
end
go

create or alter procedure sp_insert_tbIngredientesPizza(
	@pizzaId int,
	@descricao varchar(max)
	
)
as
begin
	insert into tbIngredientesPizza(pizzaId,descricao) values (@pizzaId,@descricao)
end
go

create or alter procedure sp_update_tbPizza(
	@id int,
	@descricao varchar(max)
)
as
begin
	update tbPizza set descricao = @descricao where @id = id
end
go

create or alter procedure sp_update_tbIngredientesPizza(
	@id int,
	@pizzaId int,
	@descricao varchar(max)
	
)
as
begin
	update tbIngredientesPizza set pizzaId = @pizzaId, descricao = @descricao where id = @id
end
go
