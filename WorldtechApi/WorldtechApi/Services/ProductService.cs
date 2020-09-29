using System.Collections.Generic;
using WorldtechApi.Models;


namespace WorldtechApi.Services
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts()
        {
            var products = new List<Product>()
            {
                new Product()
                {
                    Id = 0,
                    Category = ProductCategory.Computer,
                    Name = "Alienware Aurora R9",
                    Price = 1420,
                    Description = $"Alienware is a household name when it comes to gaming desktops that share a, shall we say, unique aesthetic. While the extraterrestrial styling may not appeal to everyone, their performance remains undeniable. The Aurora R9 is a compact design that often punches well above its weight. This GeForce RTX 2080 build, paired with an Intel i7 9700K ensures quality framerates at 4K, and the Alienware AIO cooling system will help keep the cozy interior of the case at a reasonable temperature.",
                    Image = "alienwareAurora.jpg"
                },
                new Product()
                {
                    Id = 0,
                    Category = ProductCategory.Computer,
                    Name = "Corsair One i164",
                    Price = 3500,
                    Description = "One of our highest rated prebuilt gaming PCs is back in an updated model, the Corsair One i164. It’s still the same small form factor PC, but with updated hardware, a revamped internal layout, and a few other slight changes. The case design still looks like something straight out of Tron. The CPU and GPU both use independent liquid cooling solutions, and all the hot air is pumped out by a single 140mm maglev fan. The PSU now sits below the motherboard, and some of the USB ports have been re-positioned on the front of the case, but that’s the extent of the non-component changes.",
                    Image = "corsairOne.jpg"
                },
                new Product()
                {
                    Id = 0,
                    Category = ProductCategory.Computer,
                    Name = "HP (Hewlett Packard) Omen Obelisk",
                    Price = 1100,
                    Description = "Hewlett Packard has been around since before the second World War, and that historical expertise is evident in the design and construction of the Omen Obelisk. The Obelisk is highly customizable, starting with a GTX 1060 and Ryzen 5 2500X and reaching up some top class parts—the original review unit we received packed an RTX 2080 and an 8th Gen Core i7 8700, so you'll be ready for the moment when ray tracing stops being a buzzword and starts being an essential feature (any day now, right?).",
                    Image = "omenObelisk.jpg"
                },
                new Product()
                {
                    Id = 0,
                    Category = ProductCategory.Computer,
                    Name = "Lenovo Legion C530 Cube",
                    Price = 920,
                    Description = "The Legion C530 Cube is a unique system that’s designed with portability in mind. A mere 24 pounds and replete with an integrated carrying handle, the C530 can easily be moved across the room or the country.And don’t be fooled by its diminutive size.Its 8th generation Intel processor and 128 GB SSD is packed with the power of a larger PC.Even better you have the ability to choose whether you want a NVIDIA GeForce GTX 1060, 1050 Ti or 1050 graphics card.",
                    Image = "lenovoCube.jpg"
                },
                new Product()
                {
                    Id = 0,
                    Category = ProductCategory.Computer,
                    Name = "Alienware R7",
                    Price = 1700,
                    Description = "The Aurora R7 is designed with a chassis equipped with a tool-less design, so removing the lid off for upgrades is a breeze. Aside from being highly-upgradable, Alienware’s Aurora R7 comes powered by a Intel Core i7 8700 processor faster than previous versions of the gaming PC. With all these factors combined, the Aurora R7 amounts to an impressive gaming PC. ",
                    Image = "auroraR7.jpg"
                },
                new Product()
                {
                    Id = 0,
                    Category = ProductCategory.Computer,
                    Name = "SkyTech Blaze 2",
                    Price = 1150,
                    Description = "Despite its small size — and relatively small price tag — SkyTech’s Blaze II comes packed with a powerful punch. But with the money you're saving on the powerful system, you won't be breaking the bank completely and can get the most use out of it before it's time for the latest-and-greatest.",
                    Image = "skytechBlaze.jpg"
                },
                new Product()
                {
                    Id = 0,
                    Category = ProductCategory.Computer,
                    Name = "Dell G5",
                    Price = 1080,
                    Description = "The Dell G5 is a compact rig that you get at an affordable price. It has got easily accessible ports, but a proprietary motherboard and a power supply meant for a server mean that parts beyond the RAM, CPU and GPU aren’t easily upgradeable.",
                    Image = "dellG5.jpg"
                },
                new Product()
                {
                    Id = 0,
                    Category = ProductCategory.Computer,
                    Name = "Alienware Aurora R10",
                    Price = 1330,
                    Description = "For anyone after a bit more style, the Aurora R10 certainly delivers. But its sleek and space-esque design isn’t the only defining feature: The technology speaks for itself. The Ryzen 5 CPU and RTX 2060 GPU are worth the few extra hundred dollars, as they perform leaps and bounds above other entry level PCs. ",
                    Image = "auroraR10.jpg"
                },
                new Product()
                {
                    Id = 0,
                    Category = ProductCategory.Computer,
                    Name = "CLX Set",
                    Price = 1500,
                    Description = "While it doesn’t have a whole lot of storage (only 240GB SSD), that can be remedied by the addition of a hard drive should you need it. As a bonus, there is a full system warranty as well as a one-year parts warranty, and for the less-mechanically minded, a free lifetime tech support.",
                    Image = "clxSet.jpg"
                },


                // Gadgets 
                new Product()
                {
                    Id = 0,
                    Category = ProductCategory.Gadget,
                    Name = "Logitech Gaming Headset",
                    Price = 50,
                    Description = "Feel the sounds deeply and enter the world of games. This headset is enhanced with the most advanced audio technology. You'll hear the unheard with the Logitech headset because audio drivers deliver an incredible sound experience, so you'll hear the sounds very detailed. It makes you feel the game up to 12 hours without wires.",
                    Image = "logitechHeadset.jpg"
                },
                new Product()
                {
                    Id = 0,
                    Category = ProductCategory.Gadget,
                    Name = "HyperX Keyboard",
                    Price = 80,
                    Description = "The HyperX Alloy FPS RGB™ is a great-looking, high-performance keyboard designed to make sure that both your skills and style are on full display. The exposed LEDs on the keyswitches amp up brightness of the RGB backlighting which can be customized with the easy-to-use HyperX NGenuity software to make your stream really stand out.",
                    Image = "hyperXKeyboard.jpg"
                },
                new Product()
                {
                    Id = 0,
                    Category = ProductCategory.Gadget,
                    Name = "Logitech Hero",
                    Price = 90,
                    Description = "In addition to the core performance and personalization features, many details were thoughtfully engineered and designed. Look for primary buttons with mechanical switches, braided cable with hook and loop cable tie, rubberized side grips, magnetic weight-cavity door, and more.",
                    Image = "mouse.jpg"
                },
                new Product()
                {
                    Id = 0,
                    Category = ProductCategory.Gadget,
                    Name = "Blue Yeti USB Microphone",
                    Price = 210,
                    Description = "Yeti is a side-address condenser microphone, so you can capture the best sound by going face-to-face with it. The microphone can also be folded down for easy portability, or removed completely from its base for mounting directly on a mic stand or Radius II shockmount.",
                    Image = "yetiMicrophone.jpg"
                },
                new Product()
                {
                    Id = 0,
                    Category = ProductCategory.Gadget,
                    Name = "Alienware AW2518HF Monitor",
                    Price = 450,
                    Description = "The AW2518HF is designed for enthusiasts and delivers a futuristic style and precise form with solid stability. This is thanks to the lightning-fast 240Hz native refresh rate combined with 1ms response time which delivers buttery-smooth gameplay with no input lag. All this comes packed in a 25 - inch LED display that can hold a resolution of up to 1920 x 1080 pixels, and it strikes a great balance between what it offers and how much it costs.",
                    Image = "alienwareMonitor.jpg"
                },
                new Product()
                {
                    Id = 0,
                    Category = ProductCategory.Gadget,
                    Name = "HyperX Cloud 2 Headset",
                    Price = 100,
                    Description = "The Cloud II is an affordable headset that gives gamers plenty of bang for the buck. With both noise and echo cancellation provided by the external sound card, the microphone stands above what you would usually get with today's headsets.",
                    Image = "cloudHeadset.jpg"
                },
                new Product()
                {
                    Id = 0,
                    Category = ProductCategory.Gadget,
                    Name = "Logictech Chaos Spectrum mouse",
                    Price = 110,
                    Description = "Chaos Spectrum comes equipped with the PMW3366 optical sensor — widely regarded as the best mouse sensor on the market. PMW3366 has zero smoothing, filtering or acceleration across the entire DPI range (200-12,000DPI), delivering exceptional tracking accuracy and consistent responsiveness at any speed.",
                    Image = "chaosSpectrumMouse.jpg"
                },
                new Product()
                {
                    Id = 0,
                    Category = ProductCategory.Gadget,
                    Name = "Alienware Keyboard AW768",
                    Price = 80,
                    Description = "The Alienware Pro Gaming Keyboard AW768 is a genuinely great deal. At under 100 bucks or quid, you’re getting the toughest gaming keyboard fitted with mechanical keys, dedicated macro keys and slick aesthetics. It’s not the most feature rich keyboard in the game, but at this price, it really doesn’t need to be. ",
                    Image = "alienwareKeyboard.jpg"
                },
                new Product()
                {
                    Id = 0,
                    Category = ProductCategory.Gadget,
                    Name = "Comfortable S-5000 Chair",
                    Price = 400,
                    Description = "Designed to give a wide range of adjustability that provides users with the best comfort and ergonomic support in every position for extended periods of time. The high backrest is designed to provide greater neck, shoulder and lumbar support.",
                    Image = "alienwareChair.jpg"
                },



                // Laptops
                new Product()
                {
                    Id = 0,
                    Category = ProductCategory.Laptop,
                    Name = "Razer Blade 'Advanced Model'",
                    Price = 1600,
                    Description = "With a solid black unibody aluminium case, the latest Razer Blade feels solid, even though it’s still thin. Both the keyboard and touchpad are noticeably roomy and aside from two speakers to the sides of the keyboard, it’s also a stark, highly minimalist design",
                    Image = "razerBlade.jpg"
                },
                new Product()
                {
                    Id = 0,
                    Category = ProductCategory.Laptop,
                    Name = "Dell G3",
                    Price = 860,
                    Description = "The G3 15 sports a simple, matte-black plastic design with a hint of a race car aesthetic. Its hood has a blue Dell logo stamped at the center, and the left and right side of it have a nice curve that continues to the hinge, which also curves the way a spoiler on a car does. The hinge itself is glossy black with a G3 logo on it, and it's surrounding it is the grilles that sport a baby blue accent, and that accent goes beyond the grilles and that wraps around the entire system.",
                    Image = "dellG3.jpg"
                },
                new Product()
                {
                    Id = 0,
                    Category = ProductCategory.Laptop,
                    Name = "Alienware R2",
                    Price = 1450,
                    Description = "Experience unprecedented performance thanks to hyper-efficient voltage regulation engineered to exceed Intel® and NVIDIA® reference design requirements. With 8-phase voltage regulation on NVIDIA® GeForce® GTX 1660 Ti, NVIDIA® RTX 2060, 2070 and 2080 Max-Q design graphics and 6-phase voltage regulation on Intel® Core™ i7 and i9HK processors, the new Alienware m17 is hardwired for greater efficiency and sustained turbo frequencies, enabling longer stretches of GPU and CPU high performance.",
                    Image = "alienwareR2.jpg"
                },
                new Product()
                {
                    Id = 0,
                    Category = ProductCategory.Laptop,
                    Name = "Asus ROG Zephyrus G14",
                    Price = 1600,
                    Description = "Dynamic and ready to travel, the pioneering ROG Zephyrus G14 is the world's most powerful 14-inch Windows 10 Pro gaming laptop. Outclass the competition with up to an 8-core AMD Ryzen™ 9 4900HS CPU and potent GeForce RTX™ 2060 GPU that speed through everyday multitasking and gaming.",
                    Image = "asusRogLaptop.jpg"
                },
                new Product()
                {
                    Id = 0,
                    Category = ProductCategory.Laptop,
                    Name = "MSI GS65 Stealth",
                    Price = 1600,
                    Description = "MSI has gotten pretty good at making ultrapowerful portable gaming laptops — just take a look at the GS65 Stealth Thin. It's under 5 pounds and less than an inch thick, all while packing GPUs like Nvidia's GeForce RTX 2080. That's an achievement.",
                    Image = "msiLaptop.jpg"
                },
                new Product()
                {
                    Id = 0,
                    Category = ProductCategory.Laptop,
                    Name = "Razer Blade Pro 17",
                    Price = 2000,
                    Description = "Like the GS65 Stealth Thin, the Razer Blade Pro 17 is one of the best gaming laptops for portability and power. Its 0.8-inch thick chassis and GeForce RTX GPU lineup keep it competitive with the Stealth Thin, and it holds a very slight advantage in the temperature-control department.",
                    Image = "bladePro.jpg"
                },
                new Product()
                {
                    Id = 0,
                    Category = ProductCategory.Laptop,
                    Name = "Dell G5 15 SE",
                    Price = 1300,
                    Description = "Dell has opted to go with an all AMD configuration, with a Ryzen 5 4600H or 4800H taking care of processor duties, and the Radeon RX 5600M handling the graphics. With up to 16GB of RAM and 1TB of SSD space, the Dell G5 15 SE 2020 is a very capable laptop. ",
                    Image = "dellG5Laptop.jpg"
                },
                new Product()
                {
                    Id = 0,
                    Category = ProductCategory.Laptop,
                    Name = "Alienware M15",
                    Price = 1800,
                    Description = "Alienware M15 thin 15 Gaming Laptop silver - i7 - 16gb memory - 128 SSD hard drive - gtx 1070 graphics display. 15 - Inch gaming Laptop with the thinnest Alienware design ever.Featuring exceptional battery life, Premium materials and impressive power.",
                    Image = "alienwareM15.jpg"
                },
                new Product()
                {
                    Id = 0,
                    Category = ProductCategory.Laptop,
                    Name = "Acer Predator Helios 500",
                    Price = 1600,
                    Description = "When all you care about is power and options, then the Predator Helios should be your pick. You get plenty of extra bells and whistles with this huge 17” model as well. Most notably, there’s a four zone RGB keyboard, and three different types of ports of connecting to external monitors.",
                    Image = "acerPredator.jpg"
                }
            };

            return products;
        }

    }
}
