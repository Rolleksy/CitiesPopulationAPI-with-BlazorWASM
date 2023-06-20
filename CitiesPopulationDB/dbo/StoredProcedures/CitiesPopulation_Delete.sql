CREATE PROCEDURE [dbo].[CitiesPopulation_Delete]
	@Id int
AS
	begin
		DELETE
		from dbo.Population
		where Id = @Id
	end
