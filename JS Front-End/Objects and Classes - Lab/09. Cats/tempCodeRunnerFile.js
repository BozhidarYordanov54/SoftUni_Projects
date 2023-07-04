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
            console.log(`${this.name}, ${this.age} says Meow`);
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