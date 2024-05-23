import React, { useMemo, useState, useEffect} from 'react';
import Header from './Header'
import '../../StyleSheets/ProductDisplay.css';
import ProductCard from './ProductCard';




export default function ProductDisplay() {
    const [userProducts, setUserProducts] = useState([]);
    useEffect(() => {
        console.log(userProducts)
    }, [userProducts])
    useMemo(() => {
        fetch('https://localhost:7090/api/Admin/GetAllProducts', {
            method: 'GET',
            headers: { 'Content-Type': 'application/json' },
           

        })
            .then(response => response.json()).then((data) => {
                console.log(data)
                setUserProducts(data.ListProducts)
            })
    }, [])
    let keyIndex = 0;
    return (
        <div className="second-body">
            <header>
                <Header></Header>
            </header>
            {/*<ProductCard productData={mockProduct}></ProductCard>*/}
            {userProducts?.length > 0 && userProducts?.map((product) => {
                keyIndex++
                return <ProductCard key={`product${keyIndex}`} productData={product}></ProductCard>
                })
            }
            
            
        </div>
    )
}