Create Procedure [SecondChance].[sp_Insert]
(
	@UserID int,
	@First_Name varchar(20),
	@Email varchar(40),
	@Password varchar(20),
	@Username varchar (15)
)
as
begin
	Declare @Count int
	Declare @codereturn int 

	/* 
	   Aunque el username tiene la clausula UNIQUE, comporbamos que el username no exista, 
	   si existe devolveremos un -1 y los datos no se guadaran, en el caso de que no este el 
	   username introduciremos los datos
	*/

	/*Seleccionamos los usuarios*/
	Select @Count = COUNT(Username)
	from Users where @Username = Username

	if @Count > 0
	Begin
		/*Si existe devolvemos -1*/
		Set @codereturn = -1
	end
	else
	begin
		/*Insertamos los datos*/
		set @codereturn = 1
		Insert into Users 
		values(@First_Name, @Email, @Password, @Username)
	end

	/*Devolvemos el resultado*/
	select @codereturn as ReturnValue
end