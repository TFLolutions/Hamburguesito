import React, { useState } from 'react';
const imageUrl = "https://source.unsplash.com/random/?glazed-salmon";
const imageFrenchPotatoesUrl = "https://source.unsplash.com/random/?frenchfries";
const imageCocaColaUrl = "https://source.unsplash.com/random/?cocacola";
const imageFernetUrl = "https://source.unsplash.com/random/?fernet";
const imageFlanUrl = "https://source.unsplash.com/random/?flan"
const imageHamburguerUrl = "https://source.unsplash.com/random/?hamburguer"
// Datos de ejemplo, reemplázalos con tus datos reales.
const menuItemsData = [
  {
    id: 1,
    category: 'Entradas',
    name: 'Miso Salmón glaseado',
    description: 'Miso de sal dulce con mantequilla',
    price: '€22,00',
    imageUrl: imageUrl, // Reemplaza con la URL de tu imagen
  },
  {
    id: 2,
    category: 'Entradas',
    name: 'Papas fritas',
    description: 'Papas fritas con cheddar',
    price: '€12,00',
    imageUrl: imageFrenchPotatoesUrl, // Reemplaza con la URL de tu imagen
  },
  {
    id: 1,
    category: 'Cocktails',
    name: 'Fernet branca ',
    description: 'Fernet branca argentino',
    price: '€10,00',
    imageUrl: imageFernetUrl, // Reemplaza con la URL de tu imagen
  },
  {
    id: 1,
    category: 'Bebidas',
    name: 'Coca-cola',
    description: 'Bebida con azucar sabor coca',
    price: '€1,00',
    imageUrl: imageCocaColaUrl, // Reemplaza con la URL de tu imagen
  },
  {
    id: 1,
    category: 'Postres',
    name: 'Flan',
    description: 'Flan con dulce de leche',
    price: '€2,00',
    imageUrl: imageFlanUrl, // Reemplaza con la URL de tu imagen
  },
  {
    id: 1,
    category: 'Comidas',
    name: 'Hamburguesa con queso',
    description: 'Hamburguesa con queso cheddar y ketchup',
    price: '€2,00',
    imageUrl: imageHamburguerUrl, // Reemplaza con la URL de tu imagen
  },
  // ...otros elementos del menú...
];

const MenuTab = () => {
  const [activeTab, setActiveTab] = useState('Entradas');
  const tabs = ['Entradas', 'Bebidas','Comidas','Cocktails','Postres'];

  return (
    <div className="max-w-md mx-auto pt-2">
      {/* Tabs del menú */}
      <div className="flex space-x-2 bg-white p-2 rounded-lg shadow-md overflow-x-auto">
        {tabs.map(tab => (
          <button
            key={tab}
            className={`text-sm font-semibold rounded-full px-4 py-1 ${activeTab === tab ? 'bg-red-500 text-white' : 'text-gray-500 bg-gray-200'}`}
            onClick={() => setActiveTab(tab)}
          >
            {tab}
          </button>
        ))}
      </div>

      {/* Lista de elementos del menú */}
      <div className="mt-4">
        {menuItemsData.filter(item => item.category === activeTab).map((item) => (
          <div key={item.id} className="bg-white p-4 rounded-lg shadow-md mb-4">
            <img src={item.imageUrl} alt={item.name} className="w-full h-32 object-cover rounded-t-lg" />
            <h3 className="mt-2 text-lg font-semibold">{item.name}</h3>
            <p className="text-gray-600">{item.description}</p>
            <div className="mt-3 flex justify-between items-center">
              <span className="text-gray-800">{item.price}</span>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
};

export default MenuTab;
