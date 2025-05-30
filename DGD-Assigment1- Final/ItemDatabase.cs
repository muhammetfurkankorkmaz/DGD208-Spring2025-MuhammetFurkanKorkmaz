using System.Collections.Generic;

public static class ItemDatabase
{
    public static List<Item> AllItems = new List<Item>
    {
        // Foods
        new Item {
            Name = "Ox",
            Type = ItemType.Food,
            CompatibleWith = new List<PetType> { PetType.Dragon },
            AffectedStat = PetStat.Hunger,
            EffectAmount = 15,
            Duration = 2.5f  // Takes 2.5 seconds to eat
        },
        new Item {
            Name = "Premium Dragon Food",
            Type = ItemType.Food,
            CompatibleWith = new List<PetType> { PetType.Dragon },
            AffectedStat = PetStat.Hunger,
            EffectAmount = 30,
            Duration = 3.0f  // Takes 3 seconds to eat
        },
        new Item {
            Name = "Cerberus Food",
            Type = ItemType.Food,
            CompatibleWith = new List<PetType> { PetType.ThreeHeadedDog },
            AffectedStat = PetStat.Hunger,
            EffectAmount = 15,
            Duration = 2.0f
        },
        new Item {
            Name = "Tuna Treat",
            Type = ItemType.Food,
            CompatibleWith = new List<PetType> { PetType.ThreeHeadedDog },
            AffectedStat = PetStat.Hunger,
            EffectAmount = 25,
            Duration = 1.5f  // Quick treat
        },
        new Item {
            Name = "Live Insects",
            Type = ItemType.Food,
            CompatibleWith = new List<PetType> { PetType.Tarantula },
            AffectedStat = PetStat.Hunger,
            EffectAmount = 10,
            Duration = 1.0f
        },
        new Item {
            Name = "Roach(Half dead)",
            Type = ItemType.Food,
            CompatibleWith = new List<PetType> { PetType.Tarantula },
            AffectedStat = PetStat.Hunger,
            EffectAmount = 20,
            Duration = 2.0f
        },
        new Item {
            Name = "Flies",
            Type = ItemType.Food,
            CompatibleWith = new List<PetType> { PetType.Frog },
            AffectedStat = PetStat.Hunger,
            EffectAmount = 10,
            Duration = 0.5f  // Very quick to consume
        },
        new Item {
            Name = "Premium Frog Food",
            Type = ItemType.Food,
            CompatibleWith = new List<PetType> { PetType.Frog },
            AffectedStat = PetStat.Hunger,
            EffectAmount = 20,
            Duration = 1.0f
        },
        new Item {
            Name = "Leaves",
            Type = ItemType.Food,
            CompatibleWith = new List<PetType> { PetType.Giraffe },
            AffectedStat = PetStat.Hunger,
            EffectAmount = 15,
            Duration = 3.0f  // Takes time to chew
        },
        new Item {
            Name = "Leafy Greens",
            Type = ItemType.Food,
            CompatibleWith = new List<PetType> { PetType.Giraffe },
            AffectedStat = PetStat.Hunger,
            EffectAmount = 25,
            Duration = 4.0f  // Lots to munch through
        },
        
        // Universal Foods
        new Item {
            Name = "Vitamin Treat(Big)",
            Type = ItemType.Food,
            CompatibleWith = new List<PetType> { PetType.Dragon, PetType.ThreeHeadedDog, PetType.Giraffe },
            AffectedStat = PetStat.Hunger,
            EffectAmount = 10,
            Duration = 1.0f  // Quick treat
        },
        new Item {
            Name = "Gourmet Dinner",
            Type = ItemType.Food,
            CompatibleWith = new List<PetType> { PetType.Dragon, PetType.ThreeHeadedDog },
            AffectedStat = PetStat.Hunger,
            EffectAmount = 40,
            Duration = 5.0f  // Fancy meal takes time
        },
        
        // Toys
        new Item {
            Name = "Dragon Egg",
            Type = ItemType.Toy,
            CompatibleWith = new List<PetType> { PetType.Dragon },
            AffectedStat = PetStat.Fun,
            EffectAmount = 20,
            Duration = 4.0f  // Playing fetch takes time
        },
        new Item {
            Name = "Ox Statue",
            Type = ItemType.Toy,
            CompatibleWith = new List<PetType> { PetType.Dragon },
            AffectedStat = PetStat.Fun,
            EffectAmount = 15,
            Duration = 2.5f
        },
        new Item {
            Name = "3 headed bone",
            Type = ItemType.Toy,
            CompatibleWith = new List<PetType> { PetType.ThreeHeadedDog },
            AffectedStat = PetStat.Fun,
            EffectAmount = 20,
            Duration = 3.0f  // Playing with string
        },
        new Item {
            Name = "Toy Mouse",
            Type = ItemType.Toy,
            CompatibleWith = new List<PetType> { PetType.ThreeHeadedDog },
            AffectedStat = PetStat.Fun,
            EffectAmount = 15,
            Duration = 2.0f
        },
        new Item {
            Name = "Web(html)",
            Type = ItemType.Toy,
            CompatibleWith = new List<PetType> { PetType.Tarantula },
            AffectedStat = PetStat.Fun,
            EffectAmount = 15,
            Duration = 3.0f  // Swinging
        },
        new Item {
            Name = "Ball",
            Type = ItemType.Toy,
            CompatibleWith = new List<PetType> { PetType.Tarantula },
            AffectedStat = PetStat.Fun,
            EffectAmount = 10,
            Duration = 1.5f
        },
        new Item {
            Name = "Rock, a big rock",
            Type = ItemType.Toy,
            CompatibleWith = new List<PetType> { PetType.Frog },
            AffectedStat = PetStat.Fun,
            EffectAmount = 10,
            Duration = 2.0f  // Watching bubbles
        },
        new Item {
            Name = "Water Plant",
            Type = ItemType.Toy,
            CompatibleWith = new List<PetType> { PetType.Frog },
            AffectedStat = PetStat.Fun,
            EffectAmount = 15,
            Duration = 1.5f
        },
        new Item {
            Name = "Chew Toy",
            Type = ItemType.Toy,
            CompatibleWith = new List<PetType> { PetType.Giraffe },
            AffectedStat = PetStat.Fun,
            EffectAmount = 15,
            Duration = 3.5f  // Lots of chewing
        },
        new Item {
            Name = "Necklace",
            Type = ItemType.Toy,
            CompatibleWith = new List<PetType> { PetType.Giraffe },
            AffectedStat = PetStat.Fun,
            EffectAmount = 20,
            Duration = 4.0f  // Running through tunnels
        },
        
        // Universal Toys
        new Item {
            Name = "Ball",
            Type = ItemType.Toy,
            CompatibleWith = new List<PetType> { PetType.Dragon, PetType.ThreeHeadedDog, PetType.Giraffe },
            AffectedStat = PetStat.Fun,
            EffectAmount = 10,
            Duration = 2.0f
        },
        
        // Sleep Items
        new Item {
            Name = "Comfy Bed",
            Type = ItemType.Toy,
            CompatibleWith = new List<PetType> { PetType.Dragon, PetType.ThreeHeadedDog },
            AffectedStat = PetStat.Sleep,
            EffectAmount = 30,
            Duration = 6.0f  // Takes time to fall asleep
        },
        new Item {
            Name = "Pet Blanket",
            Type = ItemType.Toy,
            CompatibleWith = new List<PetType> { PetType.Dragon, PetType.ThreeHeadedDog, PetType.Giraffe },
            AffectedStat = PetStat.Sleep,
            EffectAmount = 20,
            Duration = 4.0f
        },
        new Item {
            Name = "Cave Decoration",
            Type = ItemType.Toy,
            CompatibleWith = new List<PetType> { PetType.Tarantula },
            AffectedStat = PetStat.Sleep,
            EffectAmount = 25,
            Duration = 3.0f
        },
        new Item {
            Name = "Another smaller frog",
            Type = ItemType.Toy,
            CompatibleWith = new List<PetType> { PetType.Frog },
            AffectedStat = PetStat.Sleep,
            EffectAmount = 15,
            Duration = 2.0f
        },
        new Item {
            Name = "Long Tree",
            Type = ItemType.Toy,
            CompatibleWith = new List<PetType> { PetType.Giraffe },
            AffectedStat = PetStat.Sleep,
            EffectAmount = 25,
            Duration = 5.0f  // Takes time to get comfortable
        }
    };
}
