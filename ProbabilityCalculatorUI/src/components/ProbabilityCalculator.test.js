import { render, screen, fireEvent, waitFor, act } from '@testing-library/react';
import '@testing-library/jest-dom';
import axios from 'axios';
import ProbabilityCalculator from './ProbabilityCalculator';


// Ensure axios is mocked
jest.mock('axios');

describe('ProbabilityCalculator', () => {
    beforeEach(() => {
        axios.post = jest.fn(); // Explicitly define axios.post as a mock function
        axios.post.mockClear();  // Clear previous mock calls 
        axios.post.mockResolvedValueOnce({ data: { result: 0.25 } });
    });

    test('renders the form correctly', () => {
        render(<ProbabilityCalculator />);

        // Check for labels
        expect(screen.getByLabelText(/Probability A/i)).toBeInTheDocument();
        expect(screen.getByLabelText(/Probability B/i)).toBeInTheDocument();
        expect(screen.getByLabelText(/Operation/i)).toBeInTheDocument();

        // Check for the button
        expect(screen.getByRole('button', { name: /Calculate/i })).toBeInTheDocument();
    });

    test('displays validation error for out-of-range probabilities', async () => {
        render(<ProbabilityCalculator />);
    
        // Select the input and set an invalid value
        const probabilityAInput = screen.getByLabelText(/Probability A/i);
        fireEvent.change(probabilityAInput, { target: { value: '-1' } });
    
        // Check if the field is invalid
        expect(probabilityAInput.checkValidity()).toBe(false);
        expect(probabilityAInput.validity.rangeUnderflow).toBe(true); // specific error for min value
    
        // Optionally, trigger form submission to make sure it stops due to invalid input
        const submitButton = screen.getByRole('button', { name: /Calculate/i });
        fireEvent.click(submitButton);
    
        // Check if the form has been prevented from submitting
        expect(probabilityAInput.checkValidity()).toBe(false);
    });
    

    test('submits form and displays result on success CombinedWith', async () => {
        axios.post.mockResolvedValueOnce({ data: { result: 0.25 } });

        render(<ProbabilityCalculator />);

        fireEvent.change(screen.getByLabelText(/Probability A/i), { target: { value: '0.5' } });
        fireEvent.change(screen.getByLabelText(/Probability B/i), { target: { value: '0.5' } });
        fireEvent.change(screen.getByLabelText(/Operation/i), { target: { value: 'CombinedWith' } });

        fireEvent.click(screen.getByRole('button', { name: /Calculate/i }));

        // Use findBy* to automatically wait for the element to appear
        const resultElement = await screen.findByText('Result: 0.25');
        expect(resultElement).toBeInTheDocument();

        expect(axios.post).toHaveBeenCalledWith(
            `${process.env.REACT_APP_API_BASE_URL}/api/probabilities/calculate`,
            {
                probabilityA: 0.5,
                probabilityB: 0.5,
                operation: 'CombinedWith',
            }
        );
    });

    test('submits form and displays result on success Either', async () => {
        axios.post.mockResolvedValueOnce({ data: { result: 0.75 } });

        render(<ProbabilityCalculator />);

        fireEvent.change(screen.getByLabelText(/Probability A/i), { target: { value: '0.5' } });
        fireEvent.change(screen.getByLabelText(/Probability B/i), { target: { value: '0.5' } });
        fireEvent.change(screen.getByLabelText(/Operation/i), { target: { value: 'Either' } });

        fireEvent.click(screen.getByRole('button', { name: /Calculate/i }));

        // Use findBy* to automatically wait for the element to appear
        const resultElement = await screen.findByText('Result: 0.25');
        expect(resultElement).toBeInTheDocument();

        expect(axios.post).toHaveBeenCalledWith(
            `${process.env.REACT_APP_API_BASE_URL}/api/probabilities/calculate`,
            {
                probabilityA: 0.5,
                probabilityB: 0.5,
                operation: 'Either',
            }
        );
    });


    test('displays error message on failed API call', async () => {
        // Mock a failed API response
        axios.post.mockRejectedValueOnce({ response: { data: 'Calculation failed' } });

        render(<ProbabilityCalculator />);

        // Enter valid inputs
        fireEvent.change(screen.getByLabelText(/Probability A/i), { target: { value: '0.5' } });
        fireEvent.change(screen.getByLabelText(/Probability B/i), { target: { value: '0.5' } });
        fireEvent.change(screen.getByLabelText(/Operation/i), { target: { value: 'CombinedWith' } });

        // Submit the form
        fireEvent.click(screen.getByRole('button', { name: /Calculate/i }));

        // Debug output to inspect DOM structure
        await waitFor(() => {
            screen.debug();
        });
    });

});
