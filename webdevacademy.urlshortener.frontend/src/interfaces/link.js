import PropTypes from "prop-types";

const LinkInterface = PropTypes.shape({
    id: PropTypes.number.required,
    longUrl: PropTypes.string.required,
    shortUrl: PropTypes.string.required,
    uniqueVisits: PropTypes.number.required,
});

export default LinkInterface;