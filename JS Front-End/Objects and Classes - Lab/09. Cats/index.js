function catFunctions(catsData) 
{
    class Cat
    {
        constructor(name, age)
        {
            this.name = name;
            this.age = age;
        }

        meow()
        {
            console.log(`${this.name}, age ${this.age} says Meow`);
        }
    }

    const cats = [];
  
    for (let data of catsData) 
    {
      const [name, age] = data.split(' ');
      const cat = new Cat(name, age);
      cats.push(cat);
    }
  
    for (let cat of cats) 
    {
      cat.meow();
    }
}

catFunctions(['Mellow 2', 'Tom 5']);
catFunctions(['Candy 1', 'Poppy 3', 'Nyx 2']);