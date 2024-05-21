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
        fetch('https://localhost:7090/api/Products/GetAllProducts', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                "productID": 0,
                "productName": "string",
                "price1": 0,
                "price2": 0,
                "price3": 0,
                "size1": "string",
                "size2": "string",
                "size3": "string",
                "discount": 0,
                "quantity": 0,
                "imageUrl": "string",
                "available": 0
            })

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