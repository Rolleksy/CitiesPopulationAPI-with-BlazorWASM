CREATE PROCEDURE [dbo].[CitiesPopulation_Get]
	@Id int
AS
	begin
		SELECT *
		from dbo.[Population]
		where Id = @Id;
	end

