CREATE PROCEDURE [dbo].[CitiesPopulation_Update]

	@Id int,
	@CityName nvarchar(50),
	@Population int
AS
	begin
		update dbo.[Population]
		set CityName = @CityName, Population = @Population
		where Id = @Id;
	end