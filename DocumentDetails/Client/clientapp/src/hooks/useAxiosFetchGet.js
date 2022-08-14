import { useState, useEffect } from 'react';
import useAxios from "./useAxios";

const useAxiosFetchGet = (dataUrl) => {
    const axios = useAxios();
    const [data, setData] = useState([]);
    const [fetchError, setFetchError] = useState(null);
    const [isLoading, setIsLoading] = useState(false);

    useEffect(() => {
        let isMounted = true;

        const fetchData = async (url) => {
            setIsLoading(true);
            try {
                const response = await axios.get(url);
                if (isMounted) {
                    setData(response.data);
                    setFetchError(null);
                }
            } catch (err) {
                if (isMounted) {
                    setFetchError(err.message);
                    setData([]);
                }
            } finally {
                setIsLoading(false);
            }
        }

        fetchData(dataUrl);

        const cleanUp = () => {
            isMounted = false;
        }

        return cleanUp;
    }, [dataUrl])

    return { data, setData, fetchError, isLoading };
}

export default useAxiosFetchGet