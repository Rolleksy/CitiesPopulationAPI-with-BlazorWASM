CREATE PROCEDURE [dbo].[CitiesPopulation_Insert]
	@CityName nvarchar(50),
	@Population int
AS
	begin
		insert into dbo.[Population] (CityName, Population)
		values (@CityName, @Population);
	end