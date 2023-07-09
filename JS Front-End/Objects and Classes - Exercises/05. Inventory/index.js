function inventory(heroArr)
{
    let heroes = [];

    class Hero
    {
        constructor(heroName, heroLevel, items)
        {
            this.heroName = heroName,
            this.heroLevel = heroLevel,
            this.items = items
        }
    }

    for(let i = 0; i < heroArr.length; i++)
    {
        let currentHero = heroArr[i].split(' / ');
        let heroName = currentHero[0];
        let heroLevel = parseInt(currentHero[1]);
        let items = currentHero[2];

        let hero = new Hero(heroName, heroLevel, items);
        heroes.push(hero);
    }

    heroes.sort(function(a, b)
    {
        return a.heroLevel - b.heroLevel;
    });

    for(let i = 0; i < heroes.length; i++)
    {
        console.log(`Hero: ${heroes[i].heroName} \nlevel => ${heroes[i].heroLevel} \nitems => ${heroes[i].items}`);
    }
}

inventory([
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'
]);