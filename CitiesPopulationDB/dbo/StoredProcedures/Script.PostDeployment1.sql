if not exists (select 1 from dbo.Population)
	begin
		insert into [CitiesPopulation].[dbo].[Population] (CityName, Population)
		values ('Warszawa', 1792718),
				('Kraków', 780796),
				('Gdansk', 470633);
	end