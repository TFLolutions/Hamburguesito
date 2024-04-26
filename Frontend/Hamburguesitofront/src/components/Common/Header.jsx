import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { SearchIcon, ShoppingCartIcon, MenuIcon, UserCircleIcon } from '@heroicons/react/outline';

function Header() {
    const [isMenuOpen, setIsMenuOpen] = useState(false);

    return (
        <header className="bg-white shadow">
            <div className="container mx-auto px-6 py-3 flex justify-between items-center">
                <img src="/HamburguesitAppIcon.PNG" className="h-8 w-8" />
                <Link to="/" className="text-3xl ml-2 font-bold text-gray-700">Hamburguesito</Link>

                <div className="flex-1 flex items-center justify-center sm:justify-start">
                    <div className="w-full sm:block hidden">
                        <input type="search" className="w-full px-4 py-2 ml-2 rounded-md border-2 border-black focus:border-black focus:ring-0" placeholder="Buscar platos o comidas" />
                    </div>
                </div>

                <div className="ml-4 flex items-center justify-end">
                    <Link to="/cart" className="text-gray-700">
                        <ShoppingCartIcon className="h-6 w-6" />
                    </Link>

                    <div className="ml-2">
                        <UserCircleIcon className="h-6 w-6" />
                    </div>

                    <div className="ml-2">
                        <MenuIcon className="h-6 w-6 cursor-pointer md:hidden" onClick={() => setIsMenuOpen(!isMenuOpen)} />
                    </div>
                </div>
            </div>

            <div className={`md:hidden ${isMenuOpen ? 'flex' : 'hidden'} flex-col items-center justify-center`}>
                <button type="button" className="text-white hover:text-blue-200 focus:outline-none focus:text-blue-200" aria-label="toggle menu" onClick={() => setIsMenuOpen(!isMenuOpen)}>
                    <svg viewBox="0 0 24 24" className="h-6 w-6 fill-current">
                        <path fillRule="evenodd" d="M4 5h16v2H4V5zm0 6h16v2H4v-2zm0 6h16v2H4v-2z"></path>
                    </svg>
                </button>
                <Link to="/news" className="py-2 px-4 text-sm w-full text-left hover:bg-gray-100 text-center">Últimas Novedades</Link>
                <Link to="/best-sell" className="py-2 px-4 text-sm w-full text-left hover:bg-gray-100 text-center">Los más vendidos</Link>
                <Link to="/onTop" className="py-2 px-4 text-sm w-full text-left hover:bg-gray-100 text-center">Productos del momento</Link>
            </div>
        </header>
    );
}

export default Header;
