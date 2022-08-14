import { useState, React } from 'react';
import '../App.css';
import { useNavigate } from "react-router-dom";
import { Alert, Form } from 'react-bootstrap';
import LoadingSpin from "react-loading-spin";
import { Table, Thead, Tbody, Tr, Th, Td } from 'react-super-responsive-table';
import 'react-super-responsive-table/dist/SuperResponsiveTableStyle.css';
import useAxiosFetchGet from "../hooks/useAxiosFetchGet";
import useAxios from '../hooks/useAxios';

function Documents() {
    const axios = useAxios();
    let url = `/api/documents/main`;
    let navigate = useNavigate(); 
    const [isFiltered, setIsFiltered] = useState(false);
    const [filteredDocumentData, setFilteredDocumentData] = useState([]);
    function routeChange(documentId){ 
        let path = documentId.toString(); 
        navigate(path);
    }

    const changeFilter = (e) => {
        e.preventDefault();
        setIsFiltered(true);
        setFilteredDocumentData(documentData.filter(document => document.title.toLowerCase().includes(e.target.value.toLowerCase())));
    }

	  const { data: documentData, setData: setDocumentData, fetchError, isLoading } = useAxiosFetchGet(url);

    const renderDocument = (document) => {
        return (
        <Tr>
            <Td className="bordered clickable" onClick={() => routeChange(document.id)}>{document.title}</Td>
            <Td className="bordered">{document.extension}</Td>
            <Td className="bordered">{document.source}</Td>
        </Tr>
        )
    }
    return (<> 
    <Form.Control type="text" placeholder="Type to filter by title..." onChange={(e) => changeFilter(e)}/>
    <Table>
      <Thead>
        <Tr>
          <Th className="bordered">Title</Th>
          <Th className="bordered">Extension</Th>
          <Th className="bordered">Source</Th>
        </Tr>
      </Thead>
      <Tbody>
        {isFiltered ? (filteredDocumentData.map(renderDocument)) : (documentData.map(renderDocument))}
      </Tbody>
    </Table>
    {isLoading && <h1><LoadingSpin /></h1>}
	  {fetchError && <Alert variant='danger'>{fetchError}</Alert>}
 </>);
}

export default Documents;