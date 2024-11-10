import axios from 'axios';

export const calculateProbability = async (probabilityA, probabilityB, operation) => {
    const probabilityRequest = { probabilityA, probabilityB, operation };

    const response = await axios.post(
        `${process.env.REACT_APP_API_BASE_URL}/api/probabilities/calculate`,
        probabilityRequest
    );

    return response.data.result;
};
