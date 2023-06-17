CREATE PROCEDURE [dbo].[CitiesPopulation_GetAll]
	
AS
	begin
		SELECT *
		from dbo.[Population];
	end

